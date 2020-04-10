import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  currentUser : User = new User("Stefan", "Dzogovic", "dzoga123", "sifra123", "Ulica");
}
