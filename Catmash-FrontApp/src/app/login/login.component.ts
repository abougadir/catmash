import { Component, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public email: string;
  public motDePasse: string;

  private readonly POST_LOGIN = environment.apiUrl + 'user/login';

  constructor(
    private http: HttpClient
  ) { }

  onLoginSubmit() {
    this
      .http
      .post<{ accessToken: string }>(
        this.POST_LOGIN,
        {
          Email: this.email,
          Password: this.motDePasse
        })
      .subscribe(
        token => {
          localStorage.setItem('access_token', token.accessToken);
          window.location.href = '/vote';
        });
  }
}
