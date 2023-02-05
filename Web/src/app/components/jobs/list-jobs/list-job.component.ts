import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

import {JobService} from "../service/job-service.service";
import {CurrencyPipe} from "@angular/common";
import {Job} from "../model/job.model";

@Component({
  selector: 'app-list-job',
  templateUrl: './list-job.component.html',
  styleUrls: ['./list-job.component.scss']
})
export class ListJobComponent implements OnInit {

  jobListResponse: Job[] = [];

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private jobService: JobService,
    private currencyPipe: CurrencyPipe
  ) {
  }

  ngOnInit(): void {
    this.getAllJob()
      .then();
  }

  public transformAmount = (element: any): string => <string>this.currencyPipe.transform(element/100, 'R$');

  public async getAllJob() {
    this.jobService.getAll()
      .subscribe(
        {
          next: (job: Job[]) => {
            this.jobListResponse = job;
          },
          error: (catchError: any) => {
            let message = catchError.error.message == undefined ? catchError.message : catchError.error.message;
            this.toastr.error(message);
          }
        }
      );
  }

  public async createJob() {
    await this.router.navigate(['job/create']);
  }

  public deleteJob(id: string) {
    this.jobService.delete(id)
      .subscribe(
        {
          next: () => {
            this.toastr.success(`Vaga ${id} foi deletada com sucesso`);

            setTimeout(async () => {
              await this.getAllJob();
            }, 100)
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }
}
