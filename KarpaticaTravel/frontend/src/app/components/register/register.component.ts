import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { NgModel } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { SharedFormService } from 'src/app/shared/services/shared.form.service';
import { AuthService } from 'src/app/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  siteKey: string = environment.siteKey;

  constructor(
    public formService: SharedFormService,
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private toastr: ToastrService
  ) {
    this.formService.form = this.formBuilder.group(
      {
        email: [
          '',
          [
            Validators.required,
            Validators.pattern(this.formService.emailPattern),
          ],
        ],
        password: ['', [Validators.minLength(5), Validators.maxLength(15)]],
        username: ['', [Validators.minLength(5), Validators.maxLength(15)]],
        phone: [''],
        recaptcha: ['', Validators.required],
      },
      { updateOn: 'change' }
    );
  }

  ngOnInit(): void {}

  register(form: FormGroup): void {
    console.log(form.value);
    this.authService
      .createUser({
        id: '00000000-0000-0000-0000-000000000000',
        email: form.value.email,
        password: form.value.password,
        username: form.value.username,
        phone: form.value.phone,
      })
      .subscribe(
        () => {
          this.toastr
            .success('You have successfully created an account!', 'Account')
            .onHidden.subscribe(() => {
              this.router.navigateByUrl('login');
            });
        },
        (err) => {
          console.log(err);
        }
      );
  }
}
