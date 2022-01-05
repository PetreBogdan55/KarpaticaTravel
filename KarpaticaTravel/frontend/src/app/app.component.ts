import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DeviceDetectorService } from 'ngx-device-detector';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'frontend';

  version_x = 1;
  version_y = 0;
  version_z = 0;

  deviceInfo: any;
  os = 'Unknown';
  deviceType = 'Unknown';
  browser = 'Unknown';
  browserVersion = 'Unknown';

  constructor(
    private _router: Router,
    private deviceService: DeviceDetectorService,
    private authService: AuthService
  ) {
    this.detectDevice();
  }

  detectDevice() {
    this.deviceInfo = this.deviceService.getDeviceInfo();
    this.os = this.deviceService.os;
    this.deviceType = this.deviceService.deviceType;
    this.deviceType =
      this.deviceType.charAt(0).toUpperCase() + this.deviceType.slice(1);
    this.browser = this.deviceService.browser;
    this.browserVersion = this.deviceService.browser_version;
  }

  public navigateToLogin() {
    this._router.navigate(['login']);
  }

  public navigateToDashboard() {
    this._router.navigate(['start']);
  }

  public navigateToSettings() {
    this._router.navigate(['settings']);
  }

  public navigateToBookings() {
    this._router.navigate(['bookings']);
  }

  public navigateToActivities() {
    this._router.navigate(['activities']);
  }

  public navigateToReviews() {
    this._router.navigate(['reviews/' + this.authService.getId()]);
  }

  public navigateToHome() {
    this._router.navigate(['home']);
  }
}
