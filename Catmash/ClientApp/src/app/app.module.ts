import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { VoteComponent } from './vote/vote.component';
import { RankComponent } from './ranking/rank.component';
import { LoginComponent } from './login/login.component';
import { SubscriptionComponent } from './subscription/subscription.component';
import { VoteService } from './core/services/vote.service';
import { TokenInterceptor } from './core/interceptor/token.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RankComponent,
    VoteComponent,
    LoginComponent,
    SubscriptionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: RankComponent, pathMatch: 'full' },
      { path: 'vote', component: VoteComponent },
      { path: 'login', component: LoginComponent },
      { path: 'subscripe', component: SubscriptionComponent },
    ])
  ],
  providers: [
    VoteService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
