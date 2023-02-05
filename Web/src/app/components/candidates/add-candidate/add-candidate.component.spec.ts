import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCandidateComponent } from './add-candidate.component';
import {Router} from "@angular/router";
import {IndividualConfig, ToastrService} from "ngx-toastr";
import {CandidateService} from "../service/candidate-service.service";
import {HttpClient} from "@angular/common/http";
import {RouterTestingModule} from "@angular/router/testing";
import {GenericHttpClient} from "../../../service/generic-http-client.service";

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
describe('AddCandidateComponent', () => {
  let component: AddCandidateComponent;
  let fixture: ComponentFixture<AddCandidateComponent>;

  let httpClientSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(async () => {
    var genericHttpClient = new GenericHttpClient(httpClientSpy);
    var candidateService = new CandidateService(genericHttpClient);

    await TestBed.configureTestingModule({
      declarations: [ AddCandidateComponent ],
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
          provide: CandidateService,
          useValue: candidateService
        }
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});
