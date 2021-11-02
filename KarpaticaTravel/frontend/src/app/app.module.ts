import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { SharedModule } from './shared/modules/shared.module'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { LoginComponent } from './components/login/login.component'
import { StartComponent } from './components/start/start.component'
import { RegisterComponent } from './components/register/register.component'

@NgModule({
  declarations: [
    AppComponent,
    StartComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
