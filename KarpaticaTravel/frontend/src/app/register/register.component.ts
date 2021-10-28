import { Component, OnInit } from '@angular/core'
import { NgForm } from '@angular/forms'
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { Router } from '@angular/router'
import { NgModel } from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  public signupForm!: FormGroup

  constructor(private formBuilder: FormBuilder, private router: Router) {
    this.signupForm = this.formBuilder.group({
      email: ['', Validators.email],
      password: ['', [Validators.minLength(5), Validators.maxLength(15)]],
      username: ['', [Validators.minLength(5), Validators.maxLength(15)]],
    })
  }

  ngOnInit() {}

  signup(): void {}
}
