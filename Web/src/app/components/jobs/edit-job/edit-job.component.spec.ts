import {Observable} from "rxjs";
import {ComponentFixture, TestBed} from '@angular/core/testing';
import {ActivatedRoute, convertToParamMap, Router} from "@angular/router";
import {RouterTestingModule} from "@angular/router/testing";
import {CurrencyPipe} from "@angular/common";
import {Pipe, PipeTransform} from "@angular/core";
import {IndividualConfig, ToastrService} from "ngx-toastr";

import {JobService} from "../service/job-service.service";
import {EditJobComponent} from './edit-job.component';
import {GenericHttpClient} from "../../../service/generic-http-client.service";
import {Job} from "../model/job.model";

const toastrServiceMock = {
  get: (id: string) => {
    return 1;
  },
  error: (
    message?: string,
    title?: string,
    override?: Partial<IndividualConfig>
  ) => {
  },
}

@Pipe({name: 'myPipe'})
class MyPipeMock implements PipeTransform {
  transform(param: any) {
    return true;
  }
}

const jobServiceMock = {
  get: (id: string): Observable<Job> => {
    return new Observable<Job>(observer => {
      setInterval(() => observer.next(new Job()), 1000);
    });
  },
}

describe('EditJobComponent', () => {
  let component: EditJobComponent;
  let fixture: ComponentFixture<EditJobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditJobComponent],
      providers: [GenericHttpClient,
        {
          provide: Router,
          useClass: RouterTestingModule
        },
        {
          provide: ToastrService,
          useValue: toastrServiceMock
        },
        {
          provide: JobService,
          useValue: jobServiceMock
        },
        {
          provide: CurrencyPipe,
          useValue: MyPipeMock
        },
        {
          provide: ActivatedRoute,
          useValue: {snapshot: convertToParamMap({id: '123'})}
        },
      ]
    });

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
