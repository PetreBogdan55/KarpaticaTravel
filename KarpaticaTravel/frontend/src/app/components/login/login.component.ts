import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { SharedFormService } from 'src/app/shared/services/shared.form.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  URL_API: string = '';

  constructor(
    public formService: SharedFormService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.formService.form = this.formBuilder.group(
      {
        password: [''],
        email: ['', Validators.pattern(this.formService.emailPattern)],
      },
      { updateOn: 'change' }
    );
  }

  login(form: FormGroup): void {
    console.log(form.value);
  }
}
