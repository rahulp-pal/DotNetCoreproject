import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthLayoutComponent } from '../../shared/layout/auth-layout/auth-layout.component';
import { SigninComponent } from './pages/signin/components/signin.component';

const routes: Routes = [
  {
    path: 'signin',
    component: AuthLayoutComponent,
    children: [
      { path: '', component: SigninComponent }
    ]
  },
  { path: '**', redirectTo: 'signin' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
