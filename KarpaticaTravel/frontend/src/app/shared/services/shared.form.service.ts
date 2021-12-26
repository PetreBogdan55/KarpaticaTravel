import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class SharedFormService {
  public form!: FormGroup;
  public emailPattern = new RegExp(
    [
      '^(([^<>()[\\]\\.,;:\\s@"]+(\\.[^<>()\\[\\]\\.,;:\\s@"]+)*)',
      '|(".+"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.',
      '[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+',
      '[a-zA-Z]{2,}))$',
    ].join('')
  );

  constructor() {}

  getUsername(): FormControl {
    return this.form.get('username') as FormControl;
  }

  isInvalid(form: FormControl): boolean {
    return form.invalid && (form.dirty || form.touched);
  }

  getPassword(): FormControl {
    return this.form.get('password') as FormControl;
  }
  getEmail(): FormControl {
    return this.form.get('email') as FormControl;
  }
}
