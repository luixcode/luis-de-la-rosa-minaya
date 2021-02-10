import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUser } from '../models/IUser';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private urlApiBase = environment.urlApiBase + '/users';

  constructor(private http: HttpClient) { }

  saveUser(user: IUser): Observable<IUser> {
    return this.http.post<IUser>(this.urlApiBase, user);
  }
}
