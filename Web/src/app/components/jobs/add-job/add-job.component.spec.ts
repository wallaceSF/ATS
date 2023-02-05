import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddJobComponent } from './add-job.component';
import {RouterTestingModule} from "@angular/router/testing";
import {IndividualConfig, ToastrModule, ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";
import {JobService} from "../service/job-service.service";
import {CurrencyPipe} from "@angular/common";
import {GenericHttpClient} from "../../../service/generic-http-client.service";
import {HttpClient} from "@angular/common/http";
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

describe('AddJobComponent', () => {
  let component: AddJobComponent;
  let fixture: ComponentFixture<AddJobComponent>;

  beforeEach(async () => {
    var genericHttpClient = new GenericHttpClient(httpClientSpy);
    var jobserve = new JobService(genericHttpClient);

    await TestBed.configureTestingModule({
      declarations: [ AddJobComponent ],
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
    fixture = TestBed.createComponent(AddJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
