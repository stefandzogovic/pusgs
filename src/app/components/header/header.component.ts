import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentUser : User;
  constructor(private data: UserService) {}


  ngOnInit(): void {
    this.data.currentUser.subscribe(user => this.currentUser = user)
  }
}
