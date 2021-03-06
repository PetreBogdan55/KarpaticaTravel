import { Component, OnDestroy, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { SharedFormService } from 'src/app/shared/services/shared.form.service';
import { ApiService } from 'src/app/services/api.service';
import { Credentials } from 'src/app/models/credentials';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  URL_API: string = '';

  constructor(
    public formService: SharedFormService,
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router,
    private eventService: EventService
  ) {}
  ngOnDestroy(): void {}

  ngOnInit(): void {
    this.formService.form = this.formBuilder.group(
      {
        password: [''],
        email: [
          '',
          [
            Validators.required,
            Validators.pattern(this.formService.emailPattern),
          ],
        ],
      },
      { updateOn: 'change' }
    );
  }

  login(form: FormGroup): void {
    this.authService.loginUser(form.value as Credentials).subscribe(
      (next) => {
        this.eventService.emitUsername(next.username as string);
        this.toastr
          .success('Logged in', 'Login status', {
            positionClass: 'toast-top-right',
          })
          .onHidden.subscribe(() => {
            this.authService.saveToken(next['token']);
            this.authService.saveUsername(next['username']);
            this.authService.saveId(next['id']);
            this.authService.saveIsOwner(next['isOwner']);
            if (this.authService.getIsOwner() == 'true')
              this.router.navigateByUrl('admin');
            else this.router.navigateByUrl('home');
          });
      },
      (err) => {
        this.toastr.error('Wrong credentials!', 'Login status', {
          positionClass: 'toast-top-right',
        });
      }
    );
  }
}
