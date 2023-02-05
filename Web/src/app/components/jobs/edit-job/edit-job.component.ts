import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {CurrencyPipe} from "@angular/common";

import {JobService} from "../service/job-service.service";
import {Job} from "../model/job.model";

@Component({
  selector: 'app-edit-job',
  templateUrl: './edit-job.component.html',
  styleUrls: ['./edit-job.component.scss']
})
export class EditJobComponent implements OnInit {
  id: string;

  public jobModel: Job = new Job();

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private jobService: JobService,
    private currencyPipe: CurrencyPipe,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.getJobById();
  }

  public transformAmount = (element: any): void => {
    let isValidNumeric = /^\d+$/.test(element);

    if (element == null || !isValidNumeric) {
      this.jobModel.salary = null;
      return;
    }

    this.jobModel.salary = this.currencyPipe.transform(element, 'R$');
  };

  public getJobById() {
    this.jobService.get(this.id)
      .subscribe(
        {
          next: (job: Job) => {
            this.jobModel = job;
            this.jobModel.salary = <string>this.currencyPipe.transform(<any>this.jobModel.salary/100, 'R$')
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }

  public update() {
    this.jobService.update(this.id, this.jobModel)
      .subscribe(
        {
          next: (job: Job) => {
            this.router.navigate(['/job/list']).then(() => {
              this.toastr.success(`Vaga ${job.id} foi atualizada com sucesso`);
            });
          },
          error: (catchError: any) => {
            this.toastr.error(catchError.error.message);
          }
        }
      );
  }
}
