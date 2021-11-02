import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms'
import { Router } from '@angular/router'
import { NgModel } from '@angular/forms'
import { environment } from 'src/environments/environment'
import { NgForm } from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  public signupForm!: FormGroup
  siteKey: string = environment.siteKey

  constructor(private formBuilder: FormBuilder, private router: Router) {
    this.signupForm = this.formBuilder.group(
      {
        email: ['', Validators.required],
        password: ['', [Validators.minLength(5), Validators.maxLength(15)]],
        username: ['', [Validators.minLength(5), Validators.maxLength(15)]],
        recaptcha: ['', Validators.required],
      },
      { updateOn: 'change' },
    )
  }

  ngOnInit(): void {}

  getUsername(): FormControl {
    return this.signupForm.get('username') as FormControl
  }

  isInvalid(form: FormControl): boolean {
    return form.invalid && (form.dirty || form.touched)
  }

  getPassword(): FormControl {
    return this.signupForm.get('password') as FormControl
  }
  getEmail(): FormControl {
    return this.signupForm.get('email') as FormControl
  }

  register(form: FormGroup): void {
    console.log(form.value)
  }
}
