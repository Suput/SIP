import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { MainComponent } from './main/main.component';
import { DocsComponent } from './main/docs/docs.component';
import { MessagesComponent } from './main/messages/messages.component';
import { HelpComponent } from './main/help/help.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { NotauthComponent } from './notauth/notauth.component';
import { AppComponent } from './app.component';
import { ConflictComponent } from './conflict/conflict.component';
import { DocsDetailComponent } from './main/docs-detail/docs-detail.component';
import { AdminComponent } from './main/admin/admin.component';
import { RegisterComponent } from './main/admin/register/register.component';
import { AccountComponent } from './main/account/account.component';
import { ManageUsersComponent } from './main/admin/manage-users/manage-users.component';


const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'auth', component: AuthComponent },
  { path: 'main', component: MainComponent, children: [
    { path: 'docs', component: DocsComponent },
    { path: 'docs/:doc', component: DocsDetailComponent },
    { path: 'messages', component: MessagesComponent },
    { path: 'help', component: HelpComponent },
    { path: 'admin', component: AdminComponent, children: [
      { path: 'register', component: RegisterComponent },
      { path: 'users', component: ManageUsersComponent },
      { path: '', component: ManageUsersComponent, pathMatch: 'full' }
    ] },
    { path: 'account', component: AccountComponent }
  ] },
  { path: 'notfound', component: NotfoundComponent },
  { path: 'notauth', component: NotauthComponent },
  { path: 'conflict/:error', component: ConflictComponent },
  { path: '**', component: NotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
