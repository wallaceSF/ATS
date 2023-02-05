import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {CurrencyPipe} from "@angular/common";

import {JobService} from "../service/job-service.service";
import {Job} from "../model/job.model";

@Component({
  selector: 'app-add-job',
  templateUrl: './add-job.component.html',
  styleUrls: ['./add-job.component.scss']
})
export class AddJobComponent implements OnInit {
  public jobModel: Job = new Job();

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private jobService: JobService,
    private currencyPipe: CurrencyPipe
  ) {
  }

  ngOnInit(): void {
  }

  public transformAmount = (element: any): void => {
    let isValidNumeric = /^\d+$/.test(element);

    if (element == null || !isValidNumeric) {
      this.jobModel.salary = null;
      return;
    }

    this.jobModel.salary = this.currencyPipe.transform(element, 'R$');
  };

  public save() {
    this.jobService.persist(this.jobModel)
      .subscribe(
        {
          next: (job: Job) => {
            this.router.navigate(['/job/list']).then(() => {
              this.toastr.success(`Vaga ${job.id} foi cadastrado com sucesso`);
            });
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }
}
