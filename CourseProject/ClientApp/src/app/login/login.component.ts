import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DataSourceService } from '../data-source.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    login: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private ds: DataSourceService, private router:Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.ds.auth(this.loginForm.value['login'], this.loginForm.value['password'])
      .subscribe(res => {
        if (res)
          this.router.navigate([""]);
        else
          alert("Ошибка при авторизации!");
      });
  }

}
