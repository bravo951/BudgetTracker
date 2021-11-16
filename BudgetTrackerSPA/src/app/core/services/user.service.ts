import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserItem } from 'src/app/shared/models/userItem';
import { HttpClient } from '@angular/common/http';
import { UserDetail } from 'src/app/shared/models/userDetail';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  //https://localhost:44346/api/User/users
  //home calls it
  getUserList() : Observable<UserItem[]>{
    return this.http.get<UserItem[]>('https://localhost:44346/api/User/users')
  }

  getUserDetails(id : number) : Observable<UserDetail>{
    return this.http.get<UserDetail>(`https://localhost:44346/api/User/${id}`)
  }
}
