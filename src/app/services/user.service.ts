import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/entities/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private tempUser = new User("Stefan", "Dzogovic", "dzogara123", "dzogara123", "adresa", "user", "mojemail@gmail.com", "0649772931");
  private userSource;
  currentUser;

  constructor() {
    if(localStorage.getItem("user") == null)
    {
      this.userSource  = new BehaviorSubject<User>(this.tempUser);
      this.currentUser = this.userSource.asObservable(); 
      this.UserToStorage(this.tempUser);
    }
    else
    {
        this.tempUser = this.UserFromStorage();
        this.userSource  = new BehaviorSubject<User>(this.tempUser);
        this.currentUser = this.userSource.asObservable(); 
    }
   }

  changeType(type : string) {
    this.tempUser.type = type;
    this.userSource.next(this.tempUser);
  }

  UserToStorage(user : User)
  {
    localStorage.setItem('user', JSON.stringify({
      name: user.name,
      lastname: user.lastname,
      address: user.address,
      email: user.email,
      password: user.password,
      phone: user.phone,
      username: user.username,
      type: user.type,
    }));

  }

  UserFromStorage()
  {
    const raw = JSON.parse(localStorage.getItem('user'));
    const user = new User(raw.name, raw.lastname, raw.username, raw.password, raw.address, raw.type, raw.email, raw.phone);
    return user;
  }
  
}
