import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public email: string;
  public motDePasse: string;

  public error: boolean = false;
  private LOGIN_URL;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) 
  {
    this.LOGIN_URL = baseUrl + 'api/user/login';
  }

  onLoginSubmit() {
    this.error = false;
    this.http.post<{ accessToken: string }>(
        this.LOGIN_URL,
        {
          Email: this.email,
          Password: this.motDePasse
        })
      .subscribe(
        token => {
          localStorage.setItem('access_token', token.accessToken);
          window.location.href = '/vote';
        },
        err => {
          this.error = true;
        });
  }
}
