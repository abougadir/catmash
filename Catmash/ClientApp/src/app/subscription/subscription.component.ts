import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../core/models/user.model';

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
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) {
    this.POST_SUBSCRIBE = baseUrl + 'user/subscribe';
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
      .subscribe();
  }
}
