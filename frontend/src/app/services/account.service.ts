import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import LoginModel from "../models/login.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(private http: HttpClient) { }
  private urlApi = 'http://localhost:5223/api/';

  login(login: LoginModel): Observable<any> {
    return this.http.post(`${this.urlApi}Security`, login);
  }
}
