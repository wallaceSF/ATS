import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

import {GenericHttpClient} from "../../../service/generic-http-client.service";
import {environment} from "../../../../environments/environment";
import {Candidate} from "../model/candidate.model";

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  private _url = environment.API_ENDPOINT + '/api/candidate';

  constructor(private genericHttpClient: GenericHttpClient) {
  }

  public persist(candidateRequest: Candidate): Observable<Candidate> {
    return this.genericHttpClient.post<Candidate>(this._url, candidateRequest);
  }

  public update(id: string, candidateRequest: Candidate): Observable<Candidate> {
    return this.genericHttpClient.put<Candidate>(`${this._url}/${id}`, candidateRequest);
  }

  public getAll(): Observable<Candidate[]> {
    return this.genericHttpClient.getAll<Candidate>(this._url);
  }

  public get(id: string): Observable<Candidate> {
    return this.genericHttpClient.get<Candidate>(`${this._url}/${id}`);
  }

  public delete(id: string): Observable<Candidate> {
    return this.genericHttpClient.delete<Candidate>(`${this._url}/${id}`);
  }
}
