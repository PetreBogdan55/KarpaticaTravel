import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from './shared/modules/shared.module';
import {
  ToastrModule,
  ToastNoAnimation,
  ToastNoAnimationModule,
} from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { StartComponent } from './components/start/start.component';
import { RegisterComponent } from './components/register/register.component';
import { SettingsComponent } from './components/settings/settings.component';
import { ResultsComponent } from './components/results/results.component';
import { BookingsComponent } from './components/bookings/bookings.component';
import { LocationDetailsComponent } from './components/location-details/location-details.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { NgxMatIntlTelInputModule } from 'ngx-mat-intl-tel-input';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { ActivitiesComponent } from './components/activities/activities.component';

@NgModule({
  declarations: [
    AppComponent,
    StartComponent,
    LoginComponent,
    RegisterComponent,
    SettingsComponent,
    ResultsComponent,
    BookingsComponent,
    LocationDetailsComponent,
    ReviewsComponent,
    ActivitiesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxMatIntlTelInputModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      progressBar: true,
      progressAnimation: 'increasing',
      preventDuplicates: true,
      maxOpened: 1,
      newestOnTop: true,
    }),
    SharedModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true,
    },
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
