import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DataSourceService } from '../data-source.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  regForm = new FormGroup({
    login: new FormControl(''),
    password: new FormControl(''),
    cpassword: new FormControl(''),
  });

  constructor(private ds: DataSourceService, private router:Router) { }

  ngOnInit() {
  }

  onSubmit() {
    if (this.regForm.value['password'] == this.regForm.value['cpassword']) {
      this.ds.register(this.regForm.value['login'], this.regForm.value['password'])
        .subscribe(res => {
          this.router.navigate(["login"]);
        }, e => { alert("Ошибка регистрации!")});
    }
    else
      alert("Пароли не совпадают!");
  }
}
