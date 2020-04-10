import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/entities/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private tempUser = new User("Stefan", "Dzogovic", "dzogara123", "dzogara123", "adresa", "user");
  private userSource = new BehaviorSubject<User>(this.tempUser);
  currentUser = this.userSource.asObservable();

  constructor() { }

  changeType(type : string) {
    this.tempUser.type = type;
    this.userSource.next(this.tempUser);
  }
  
}
