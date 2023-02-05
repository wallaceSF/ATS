import {ComponentFixture, TestBed} from '@angular/core/testing';

import {ListJobComponent} from './list-job.component';
import {RouterTestingModule} from "@angular/router/testing";
import {IndividualConfig, ToastrModule, ToastrService} from "ngx-toastr";
import {GenericHttpClient} from "../../../service/generic-http-client.service";
import {JobService} from "../service/job-service.service";
import {HttpClient} from "@angular/common/http";
import {CurrencyPipe} from "@angular/common";
import {Router} from "@angular/router";
import {Pipe, PipeTransform} from "@angular/core";

let httpClientSpy: jasmine.SpyObj<HttpClient>;

const toastrService = {
  success: (
    message?: string,
    title?: string,
    override?: Partial<IndividualConfig>
  ) => {
  },
  error: (
    message?: string,
    title?: string,
    override?: Partial<IndividualConfig>
  ) => {
  },
}

@Pipe({ name: 'myPipe' })
class MyPipeMock implements PipeTransform {
  transform(param: any) {
    console.log('mocking');
    return true;
  }
}

describe('ListJobComponent', () => {
  let component: ListJobComponent;
  let fixture: ComponentFixture<ListJobComponent>;

  beforeEach(async () => {
    var genericHttpClient = new GenericHttpClient(httpClientSpy);
    var jobserve = new JobService(genericHttpClient);

    //new GenericHttpClient(httpClientSpy)

    await TestBed.configureTestingModule({
      declarations: [ListJobComponent],
      providers: [
        {
          provide: Router,
          useClass: RouterTestingModule
        },
        {
          provide: ToastrService,
          useValue: toastrService
        },
        {
          provide: JobService,
          useValue: jobserve
        },
        {
          provide: CurrencyPipe,
          useValue: MyPipeMock
        },
      ],
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
