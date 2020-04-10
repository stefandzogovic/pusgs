import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  currentUser : User;

  constructor(private data: UserService) { }

  ngOnInit(): void {
    this.data.currentUser.subscribe(user => this.currentUser = user)
  }

}
