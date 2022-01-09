import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { ToastrService } from 'ngx-toastr';
import { Booking } from 'src/app/models/booking';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-confirm-booking',
  templateUrl: './confirm-booking.component.html',
  styleUrls: ['./confirm-booking.component.scss'],
})
export class ConfirmBookingComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<ConfirmBookingComponent>,
    private formBuilder: FormBuilder,
    private apiService: ApiService,
    private authService: AuthService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public data: { locationId: string }
  ) {}
  formGroup: FormGroup;
  checkInDate: Date;
  checkOutDate: Date;

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      checkIn: '',
      checkOut: '',
    });
  }

  confirm() {
    console.log(this.formGroup.value);
    this.checkInDate = this.formGroup.value.checkIn;

    this.apiService
      .createBooking({
        checkOutDate: this.formGroup.value.checkOut as Date,
        checkInDate: this.formGroup.value.checkIn as Date,
        id: '00000000-0000-0000-0000-000000000000',
        isCancellable: true,
        locationId: this.data.locationId,
        userId: this.authService.getId() || '',
      })
      .subscribe(
        () => {
          this.toastr.success('Booking successful!', 'Booking status');
        },
        (err) => {
          console.log(err);
        }
      );
    this.dialogRef.close();
  }

  nextStep(stepper: MatStepper) {
    stepper.next();
  }

  previousStep(stepper: MatStepper) {
    stepper.previous();
  }
}
