import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AppService {
  constructor(private http: HttpClient) {}

  getValues(): Observable<string[]> {
    return this.http.get<string[]>('/api/values');
  }
}
