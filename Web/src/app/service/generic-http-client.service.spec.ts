import { GenericHttpClient } from './generic-http-client.service';
import {HttpClient} from "@angular/common/http";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {TestBed} from "@angular/core/testing";

let httpClientSpy: jasmine.SpyObj<HttpClient>;

describe('GenericHttpClient', () => {
  it('should create an instance', () => {
    expect(new GenericHttpClient(httpClientSpy)).toBeTruthy();
  });
});
