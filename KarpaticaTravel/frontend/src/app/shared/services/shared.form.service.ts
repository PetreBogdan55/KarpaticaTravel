import { Injectable } from '@angular/core'
import { FormControl, FormGroup } from '@angular/forms'

@Injectable({
  providedIn: 'root',
})
export class SharedFormService {
  public form!: FormGroup

  constructor() {}

  getUsername(): FormControl {
    return this.form.get('username') as FormControl
  }

  isInvalid(form: FormControl): boolean {
    return form.invalid && (form.dirty || form.touched)
  }

  getPassword(): FormControl {
    return this.form.get('password') as FormControl
  }
  getEmail(): FormControl {
    return this.form.get('email') as FormControl
  }
}
