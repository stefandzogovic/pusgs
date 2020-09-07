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
  // friendList = [];
  allusers = [];
  searchText2;
  currentUser: User;
  requestUsers: Array<User>
  friends: Array<User>


  ngOnInit(): void {

    // this.friendList = this.userService.createFriendUsers();
    this.userService.currentUser.subscribe(user => this.currentUser = user)
    this.requestUsers = this.userService.requestUsers;
    this.friends = this.userService.friends;
  }

  btnCloseClick(event: Event) {
    console.log('Click!', event)
    this.router.navigateByUrl('/profile')
  }

  btnAddFriend(user:User)
  { 
    this.userService.postFriend(this.currentUser, user).subscribe(
      res => {
        console.log(res)
      },
      err => {
        console.log(err)
      }
    )
  }

  modelChange(event: Event) {
    console.log(this.currentUser)
    if (this.searchText2 == "") {
      this.allusers = []
    }
    else {
      this.userService.getUsersFromDb().subscribe(
        users => this.allusers = users,
        err => console.log(err));
      console.log(this.allusers)
    }
  } 
  
  btnAcceptFriend(id:number, user:User)
  {
    this.userService.acceptFriend(this.currentUser.id, id).subscribe()
  
    const index: number = this.requestUsers.indexOf(user)
    this.requestUsers.splice(index, 1)
    this.friends.push(user)
  }

  
  btnRemoveFriend(id:number, user: User) {
    this.userService.removeFriend(this.currentUser.id, id).subscribe()
    const index: number = this.requestUsers.indexOf(user)
    this.friends.splice(index, 1)
  }

  getAllRequests()
  {
    this.userService.getRequestsFromDb(this.currentUser).subscribe(
      res => {
        console.log(res)
      },
      err => {
        console.log(err)
      }
    )}
    
}
 