import { CandidateService } from './candidate-service.service';
import {HttpClient} from "@angular/common/http";
import {GenericHttpClient} from "../../../service/generic-http-client.service";


let httpClientSpy: jasmine.SpyObj<GenericHttpClient>;
describe('CandidateService', () => {
  it('should create an instance', () => {
    expect(new CandidateService(httpClientSpy)).toBeTruthy();
  });
});
