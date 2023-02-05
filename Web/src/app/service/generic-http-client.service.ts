import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class GenericHttpClient {

  constructor(private httpClient: HttpClient) {}

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };

  public post<T>(url: string, model: T): Observable<T> {
    return this.httpClient.post<T>(url, model, this.httpOptions);
  }

  public put<T>(url: string, model: T): Observable<T> {
    return this.httpClient.put<T>(url, model, this.httpOptions);
  }

  public getAll<TResponse>(url: string): Observable<TResponse[]> {
    return this.httpClient.get<TResponse[]>(url, this.httpOptions);
  }

  public get<TResponse>(url: string): Observable<TResponse> {
    return this.httpClient.get<TResponse>(url, this.httpOptions);
  }

  public delete<TResponse>(url: string) {
    return this.httpClient.delete<TResponse>(url, this.httpOptions);
  }
}
