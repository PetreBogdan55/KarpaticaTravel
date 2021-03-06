import { FooterComponent } from './shared/components/footer/footer.component';
import { ActivitiesComponent } from './components/activities/activities.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { ResultsComponent } from './components/results/results.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { StartComponent } from './components/start/start.component';
import { RegisterComponent } from './components/register/register.component';
import { BookingsComponent } from './components/bookings/bookings.component';
import { LocationDetailsComponent } from './components/location-details/location-details.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { AdministratorComponent } from './components/administrator/administrator.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'start', component: StartComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'results', component: ResultsComponent },
  {
    path: 'admin',
    component: AdministratorComponent,
    canActivate: [AuthGuard],
  },
  { path: 'activities', component: ActivitiesComponent },
  { path: 'results/:id', component: LocationDetailsComponent },
  {
    path: 'bookings/:id',
    component: BookingsComponent,
    canActivate: [AuthGuard],
  },
  { path: 'footer', component: FooterComponent },
  {
    path: 'reviews/:id',
    component: ReviewsComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'top' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
