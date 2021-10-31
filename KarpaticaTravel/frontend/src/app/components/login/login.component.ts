import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { NgForm } from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  URL_API: string = ''

  constructor() {}

  ngOnInit(): void {}

  login(form: NgForm): void {
    console.log(form.value)
  }
}
