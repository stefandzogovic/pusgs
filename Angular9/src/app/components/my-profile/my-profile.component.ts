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

  constructor(private data: UserService,
    private formBuilder: FormBuilder) { 
  }

  ngOnInit(): void {
    this.data.currentUser.subscribe(user => this.currentUser = user)
    this.contactForm = this.createFormGroupWithBuilder(this.formBuilder);
    this.friendList = this.data.createFriendUsers();
  }
  
  createFormGroupWithBuilder(formBuilder: FormBuilder) {
    return formBuilder.group({
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
    this.data.UserToStorage(result);
    window.alert("Succefully changed.");
  }   
}
