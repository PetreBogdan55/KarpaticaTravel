import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup } from '@angular/forms'
import { MatDialogRef } from '@angular/material/dialog'
import { ToastrService } from 'ngx-toastr'
import { ApiService } from 'src/app/services/api.service'
import { Location } from '../../models/location'

@Component({
  selector: 'app-add-location',
  templateUrl: './add-location.component.html',
  styleUrls: ['./add-location.component.scss'],
})
export class AddLocationComponent implements OnInit {
  form: FormGroup
  newLocation: Location

  constructor(
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<AddLocationComponent>,
    private apiService: ApiService,
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: '',
      address: '',
      pricePerDay: '',
      photoURL: '',
      isAvailable: '',
      distanceFromCenter: '',
    })
  }
  closeDialog() {
    this.dialogRef.close(this.newLocation)
  }

  addLocation() {
    this.newLocation = {
      id: '00000000-0000-0000-0000-000000000000',
      activityId: 'c783f010-619f-4fa2-90e7-7acf7c9260be',
      cityId: '122e8fb9-7943-4706-affe-eab07438e09c',
      address: this.form.value.address,
      distanceFromCenter: this.form.value.distanceFromCenter,
      capacity: 0,
      isAvailable: this.form.value.isAvailable,
      name: this.form.value.name,
      ownerId: '13e34d8f-9b1f-4a3d-8273-03827fca67ef',
      photo: this.form.value.photoURL,
      pricePerDay: this.form.value.pricePerDay,
    }
    this.apiService.createLocation(this.newLocation).subscribe(() => {
      this.toastr.success(
        'Location added successfully!',
        'Add operation status',
      )
    })
  }
}
