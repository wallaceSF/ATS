import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

import {CandidateService} from "../service/candidate-service.service";
import {Candidate} from "../model/candidate.model";

@Component({
  selector: 'app-list-candidates',
  templateUrl: './list-candidates.component.html',
  styleUrls: ['./list-candidates.component.scss']
})
export class ListCandidatesComponent implements OnInit {

  candidateListResponse: Candidate[] = [];
  constructor(
    private router: Router,
    private toastr: ToastrService,
    private candidateService: CandidateService
  ) {
  }

  ngOnInit(): void {
    this.getAllCandidate()
      .then();
  }

  public async getAllCandidate() {
    this.candidateService.getAll()
      .subscribe(
        {
          next: (candidate: Candidate[]) => {
            this.candidateListResponse = candidate;
          },
          error: (catchError: any) => {
            let message = catchError.error.message == undefined ? catchError.message : catchError.error.message;
            this.toastr.error(message);
          }
        }
      );
  }

  public async createCandidate() {
    await this.router.navigate(['candidate/create']);
  }

  public deleteCandidate(id: string) {
    this.candidateService.delete(id)
      .subscribe(
        {
          next: () => {
            this.toastr.success(`Candidato ${id} foi excluido com sucesso`);

            setTimeout(async () => {
              await this.getAllCandidate();
            }, 100)
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }

}
