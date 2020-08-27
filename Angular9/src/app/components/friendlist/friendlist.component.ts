import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms'
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/entities/user';

@Component({
  selector: 'app-friendlist',
  templateUrl: './friendlist.component.html',
  styleUrls: ['./friendlist.component.css']
})
export class FriendlistComponent implements OnInit {

  constructor(private router: Router, private userService: UserService) { }

  searchText;
  friendList = [];
  allusers;
  searchText2;


  ngOnInit(): void {

    this.friendList = this.userService.createFriendUsers();

  }

  btnCloseClick(event: Event)
  {
    console.log('Click!', event)
    this.router.navigateByUrl('/profile')
  }

  btnRemoveFriend(user: User)
  {
    this.friendList.splice(user.id - 1, 1)
    console.log(user)
  }

  modelChange(event: Event)
  {
    console.log('Changed')
  }
}
