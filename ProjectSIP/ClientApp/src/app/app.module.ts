import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Provider, forwardRef } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiModule } from './api/api.module';
import { AuthComponent } from './auth/auth.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiInterceptor, UserService } from './services/httpBearer/user.service';
import { MainComponent } from './main/main.component';
import { DocsComponent } from './main/docs/docs.component';
import { MessagesComponent } from './main/messages/messages.component';
import { HelpComponent } from './main/help/help.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { NotauthComponent } from './notauth/notauth.component';
import { environment } from 'src/environments/environment';
import { DatePipe } from '@angular/common';
import { DocsService } from './main/docs/docs.service';
import { ConflictComponent } from './conflict/conflict.component';
import { DocsDetailComponent } from './main/docs-detail/docs-detail.component';
import { RegisterComponent } from './main/admin/register/register.component';
import { AdminComponent } from './main/admin/admin.component';
import { AccountComponent } from './main/account/account.component';
import { ManageUsersComponent } from './main/admin/manage-users/manage-users.component';


export const API_INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  useExisting: forwardRef(() => ApiInterceptor),
  multi: true
};

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    MainComponent,
    DocsComponent,
    MessagesComponent,
    HelpComponent,
    NotfoundComponent,
    NotauthComponent,
    ConflictComponent,
    DocsDetailComponent,
    RegisterComponent,
    AdminComponent,
    AccountComponent,
    ManageUsersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ApiModule.forRoot({rootUrl: environment.baseApiUrl})
  ],
  providers: [
    DocsService, // my
    DatePipe, // ang
    UserService, // my
    ApiInterceptor, // my
    API_INTERCEPTOR_PROVIDER // my
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
