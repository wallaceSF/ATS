import { JobService } from './job-service.service';
import {GenericHttpClient} from "../../../service/generic-http-client.service";

let httpClientSpy: jasmine.SpyObj<GenericHttpClient>;

describe('JobService', () => {
  it('should create an instance', () => {
    expect(new JobService(httpClientSpy)).toBeTruthy();
  });
});
