import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

import {CandidateService} from "../service/candidate-service.service";
import {Candidate} from "../model/candidate.model";

@Component({
  selector: 'app-edit-candidate',
  templateUrl: './edit-candidate.component.html',
  styleUrls: ['./edit-candidate.component.scss']
})
export class EditCandidateComponent implements OnInit {
  id: string;

  public candidateModel: Candidate = new Candidate();

  constructor(
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router,
    private candidateService: CandidateService
  ) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.getCandidateById();
  }

  public getCandidateById() {
    this.candidateService.get(this.id)
      .subscribe(
        {
          next: (candidate: Candidate) => {
            this.candidateModel = candidate;
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }

  public update() {
    this.candidateService.update(this.id, this.candidateModel)
      .subscribe(
        {
          next: (candidate: Candidate) => {
            this.router.navigate(['/candidate/list']).then(() => {
              this.toastr.success(`Candidato ${candidate.id} foi atualizada com sucesso`);
            });
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }

  transformDate(birthDate: any) {
    const date = new Date(birthDate)
    const year = date.getFullYear() // 2019
    const day = date.getDate().toString().padStart(2, "0");
    const month = (date.getMonth() + 1).toString().padStart(2, "0");

    return `${year}-${month}-${day}`;
  }
}
