import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxCaptchaModule } from 'ngx-captcha';

const sharedModules: any[] = [
  CommonModule,
  MaterialModule,
  ReactiveFormsModule,
  FormsModule,
  NgxCaptchaModule,
];
@NgModule({
  declarations: [],
  imports: sharedModules,
  exports: sharedModules,
})
export class SharedModule {}
