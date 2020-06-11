import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRouterModule } from './app-route.module';
import { SubscriptionComponent } from './subscription/subscription.component';
import { LoginComponent } from './login/login.component';
import { TokenInterceptor } from './core/token.interceptor';
import { VoteComponent } from './vote/vote.component';
import { VoteService } from './vote.service';
import { RankComponent } from './ranking/rank.component';

@NgModule({
  declarations: [
    AppComponent,
    SubscriptionComponent,
    LoginComponent,
    VoteComponent,
    RankComponent
  ],
  imports: [
    BrowserModule,
    AppRouterModule,
    FormsModule,
    HttpClientModule
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
