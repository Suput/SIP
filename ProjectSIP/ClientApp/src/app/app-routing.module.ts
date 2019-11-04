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
import { AdminComponent } from './main/admin/admin.component';
import { RegisterComponent } from './main/admin/register/register.component';
import { AccountComponent } from './main/account/account.component';
import { ManageUsersComponent } from './main/admin/manage-users/manage-users.component';
import { EventsComponent } from './main/docs/events/events.component';
import { BuysComponent } from './main/docs/buys/buys.component';
import { SackComponent } from './main/docs/sack/sack.component';
import { EventsDetailComponent } from './main/docs/events/events-detail/events-detail.component';


const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'auth', component: AuthComponent },
  { path: 'main', component: MainComponent, children: [
    { path: 'docs', component: DocsComponent, children: [
      { path: 'events', component: EventsComponent },
      { path: 'events/:docId', component: EventsDetailComponent },
      { path: 'buys', component: BuysComponent },
      { path: 'buys/:docId', component: BuysComponent },
      { path: 'sack', component: SackComponent },
      { path: 'sack/:docId', component: SackComponent },
      { path: '', component: EventsComponent, pathMatch: 'full' }
    ] },
    { path: 'messages', component: MessagesComponent },
    { path: 'help', component: HelpComponent },
    { path: 'admin', component: AdminComponent, children: [
      { path: 'register', component: RegisterComponent },
      { path: 'users', component: ManageUsersComponent },
      { path: '', component: ManageUsersComponent, pathMatch: 'full' }
    ] },
    { path: 'account', component: AccountComponent },
    { path: '', component: AccountComponent, pathMatch: 'full' }
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
