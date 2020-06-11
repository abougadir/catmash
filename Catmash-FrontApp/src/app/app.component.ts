import { Component, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private readonly GET_LOGOUT = environment.apiUrl + 'user/logout';

  public isConnected : boolean = false;
  constructor(private http: HttpClient,
    private injector: Injector) 
  {
    if (localStorage.getItem('access_token') != null) {
      this.isConnected = true;
    }
  }

  logout() {
    localStorage.removeItem('access_token');
    this.isConnected = false;
    this.http
    .get(this.GET_LOGOUT)
    .subscribe(res => {
      this.router.navigateByUrl('/login');
    });
  }

  

  protected get router(): Router {
    return this.injector.get(Router);
  }
}
