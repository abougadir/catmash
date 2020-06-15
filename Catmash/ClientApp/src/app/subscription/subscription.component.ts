import { Component, Inject, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../core/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})
export class SubscriptionComponent {
  public nom: string;
  public prenom: string;
  public email: string;
  public motDePasse: string;

  private POST_SUBSCRIBE: string;

  constructor(
    private http: HttpClient, private injector: Injector, @Inject('BASE_URL') baseUrl: string
  ) {
    this.POST_SUBSCRIBE = baseUrl + 'api/user/subscribe';
  }

  onSubmit() {
    this
      .http
      .post(
        this.POST_SUBSCRIBE,
        { 
          User : new User(
            this.nom,
            this.prenom,
            this.email
          ),
          Password: this.motDePasse
        })
      .subscribe(success => {
        this.router.navigateByUrl('/login');
      });
  }

  protected get router(): Router {
    return this.injector.get(Router);
  }
}
