import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Provider, forwardRef } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiModule } from './api/api.module';
import { AuthComponent } from './auth/auth.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiInterceptor, UserService } from './services/httpBearer/user.service';
import { environment } from 'src/environments/environment';
import { MainComponent } from './main/main.component';
import { DocsComponent } from './docs/docs.component';
import { MessagesComponent } from './messages/messages.component';
import { HelpComponent } from './help/help.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { NotauthComponent } from './notauth/notauth.component';


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
    NotauthComponent
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
    UserService,
    ApiInterceptor,
    API_INTERCEPTOR_PROVIDER],
  bootstrap: [AppComponent]
})
export class AppModule { }
