import { Component, OnInit } from '@angular/core';
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

  private readonly POST_SUBSCRIBE = environment.apiUrl + 'user/subscribe'

  constructor(
    private http: HttpClient
  ) { }

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