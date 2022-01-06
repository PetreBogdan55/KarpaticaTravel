import { FooterComponent } from './shared/components/footer/footer.component';
import { ActivitiesComponent } from './components/activities/activities.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { ResultsComponent } from './components/results/results.component';
import { SettingsComponent } from './components/settings/settings.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { StartComponent } from './components/start/start.component';
import { RegisterComponent } from './components/register/register.component';
import { BookingsComponent } from './components/bookings/bookings.component';
import { LocationDetailsComponent } from './components/location-details/location-details.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'start', component: StartComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] },
  { path: 'results', component: ResultsComponent },
  { path: 'activities', component: ActivitiesComponent },
  { path: 'results/:id', component: LocationDetailsComponent },
  { path: 'bookings', component: BookingsComponent, canActivate: [AuthGuard] },
  { path: 'footer', component: FooterComponent},
  {
    path: 'reviews/:id',
    component: ReviewsComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
