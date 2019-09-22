import { Component, OnInit } from '@angular/core';
import { DataSourceService } from '../data-source.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  name: string = "Имя";
  surname: string = "Фамилия";
  phone: string = "81234567890";
  mail: string = "qwerty@mail.com";

  constructor(private ds: DataSourceService) { }

  ngOnInit() {
    this.ds.getProfile().subscribe(res => {
      this.name = res["firstName"];
      this.surname = res["lastName"];
      this.phone = res["phoneNumber"];
      this.mail = res["mail"];
    });
  }

  submit() {
    this.ds.updateProfile({ firstName: this.name, lastName: this.surname, phoneNumber: this.phone, mail: this.mail }).subscribe(res => alert("Данные были сохранены!"));
  }
}
