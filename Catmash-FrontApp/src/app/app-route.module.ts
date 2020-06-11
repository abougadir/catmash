import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from './core/auth.guard';
import { SubscriptionComponent } from './subscription/subscription.component';
import { LoginComponent } from './login/login.component';
import { VoteComponent } from './vote/vote.component';
import { RankComponent } from './ranking/rank.component';

const appRoutes: Routes = [
  {
    path: 'vote',
    component: VoteComponent,
    canActivate: [ AuthGuard ]
  },
  {
    path: 'ranking',
    component: RankComponent
  },
  {
    path: 'subscribe',
    component: SubscriptionComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRouterModule { }
