import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/entities/user';
import { HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private tempUser = new User(0, "Stefan", "Dzogovic", "dzogara123", "dzogara123", "adresa", "user", "mojemail@gmail.com", "0649772931");
  private userSource;
  currentUser;

  formData:User
  readonly rootURL = 'http://localhost:51185/api'

  constructor(private http:HttpClient) {
    localStorage.removeItem("user")
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

   
  postUser(user:User)
  {
    return this.http.post(this.rootURL + '/Users', user)
  }


  changeType(type : string) {
    this.tempUser.type = type;
    this.userSource.next(this.tempUser);
    this.UserToStorage(this.tempUser);
  }

  UserToStorage(user : User)
  {
    localStorage.setItem('user', JSON.stringify({
      id : user.id,
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
    const user = new User(raw.id, raw.name, raw.lastname, raw.username, raw.password, raw.address, raw.type, raw.email, raw.phone);
    return user;
  }
  
  createFriendUsers()
  {
    let friendList = new Array<User>();
    let frienListTemp =[];
    const user1 = new User(1, "Ime", "Prezime", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");
    const user2 = new User(2, "TempIme", "TempPrezime", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");
    const user3 = new User(3, "Milan", "Milanovic", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");
    const user4 = new User(4, "adfg", "gdsg", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");

    friendList.push(user1);
    friendList.push(user2);
    friendList.push(user3);
    friendList.push(user4);

    // friendList.forEach(element => {
    //     frienListTemp.push({name: element.name, lastname: element.lastname});
    // });

    return friendList;
  }

}
