import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

import {GenericHttpClient} from "../../../service/generic-http-client.service";
import {environment} from "../../../../environments/environment";
import {Job} from "../model/job.model";

@Injectable({
  providedIn: 'root'
})
export class JobService {

  private _url = environment.API_ENDPOINT + '/api/job';

  constructor(private genericHttpClient: GenericHttpClient) {
  }

  public persist(jobRequest: Job): Observable<Job> {
    if (jobRequest.salary != null) {
      jobRequest.salary = jobRequest.salary.replace(/\D/g, "");
    }

    return this.genericHttpClient.post<Job>(this._url, jobRequest);
  }

  public update(id: string, jobRequest: Job): Observable<Job> {
    if (jobRequest.salary != null) {
      jobRequest.salary = jobRequest.salary.replace(/\D/g, "");
    }

    return this.genericHttpClient.put<Job>(`${this._url}/${id}`, jobRequest);
  }

  public getAll(): Observable<Job[]> {
    return this.genericHttpClient.getAll<Job>(this._url);
  }

  public get(id: string): Observable<Job> {
    return this.genericHttpClient.get<Job>(`${this._url}/${id}`);
  }

  public delete(id: string): Observable<Job> {
    return this.genericHttpClient.delete<Job>(`${this._url}/${id}`);
  }
}
