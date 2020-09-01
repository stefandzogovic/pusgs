import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms'
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  currentUser : User;
  contactForm: FormGroup;
  friendList;
  searchText;

  constructor(private service: UserService,
    private formBuilder: FormBuilder) { 
  }
  

  ngOnInit(): void {
    this.service.currentUser.subscribe(user => this.currentUser = user)
    this.contactForm = this.createFormGroupWithBuilder(this.formBuilder);
    this.friendList = this.service.createFriendUsers();
  }
  
  createFormGroupWithBuilder(formBuilder: FormBuilder) {
    return formBuilder.group({
        id : this.currentUser.id,
        name: this.currentUser.name,
        lastname: this.currentUser.lastname,
        username: this.currentUser.username,
        email: this.currentUser.email,
        password : this.currentUser.password,
        address : this.currentUser.address,
        phone : this.currentUser.phone,
        type: this.currentUser.type
    });
  }
  onSubmit(): void{
    const result : User  = Object.assign({}, this.contactForm.value);
        
    this.service.postUser(result).subscribe(
      res => {
        console.log(res)
      },
      err => {
        console.log(err)
      }
    )
  }   
}
