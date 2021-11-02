import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms'
import { Router } from '@angular/router'
import { NgModel } from '@angular/forms'
import { environment } from 'src/environments/environment'
import { SharedFormService } from 'src/app/shared/services/shared.form.service'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  siteKey: string = environment.siteKey

  constructor(
    public formService: SharedFormService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {
    this.formService.form = this.formBuilder.group(
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

  register(form: FormGroup): void {
    console.log(form.value)
  }
}
