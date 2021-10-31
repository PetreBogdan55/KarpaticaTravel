import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgModel } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  public signupForm!: FormGroup;
  siteKey: string = environment.siteKey;

  constructor(private formBuilder: FormBuilder, private router: Router) {
    this.signupForm = this.formBuilder.group({
      email: ['', Validators.email],
      password: ['', [Validators.minLength(5), Validators.maxLength(15)]],
      username: ['', [Validators.minLength(5), Validators.maxLength(15)]],
      recaptcha: ['', Validators.required],
    });
  }

  ngOnInit() {}

  register(form: FormGroup): void {
    console.log(form.value);
  }
}
