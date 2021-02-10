import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDepartment } from '../models/IDepartment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  private urlApiBase = environment.urlApiBase + '/departments';

  constructor(private http: HttpClient) { }

  getAll(): Observable<IDepartment[]> {
    return this.http.get<IDepartment[]>(this.urlApiBase);
  }
}
