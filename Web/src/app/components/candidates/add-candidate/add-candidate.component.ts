import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

import {CandidateService} from "../service/candidate-service.service";
import {Candidate} from "../model/candidate.model";

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.scss'],

})
export class AddCandidateComponent implements OnInit {
  public candidateModel: Candidate = new Candidate();
  constructor(
    private router: Router,
    private toastr: ToastrService,
    private candidateService: CandidateService
  ) {
  }

  ngOnInit(): void {
  }

  public save() {
    this.candidateService.persist(this.candidateModel)
      .subscribe(
        {
          next: (candidate: Candidate) => {
            this.router.navigate(['/candidate/list']).then(() => {
              this.toastr.success(`Candidato ${candidate.id} foi cadastrado com sucesso`);
            });
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }
}
