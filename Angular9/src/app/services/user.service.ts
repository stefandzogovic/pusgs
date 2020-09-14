import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from 'src/entities/user';
import { HttpClient, HttpParams} from "@angular/common/http"
import { AvioCompan } from 'src/entities/aviocompany';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  // private tempUser = new User(1, "Stefan", "Dzogovic", "dzogara123", "dzogara123", "adresa", "user", "stefandzogovicpr26@gmail.com", "0649772931");
  private tempUser = new User(2, "Ime", "Prezime", "dzogara123", "password", "adresasa", "user", "stefandzogovicpr26@gmail.com", "0649774215212931");

  private userSource;
  currentUser;
  requestUsers: Array<User>;
  friends: Array<User>


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

    this.getRequestsFromDb(this.tempUser).subscribe(users => this.requestUsers = users)
    this.getFriends(this.tempUser).subscribe(friends => this.friends = friends)

   }

  
  changeType(type : string) {
    if(type == 'adminavio')
    {
      this.tempUser.type = type;
      this.http.get<AvioCompan>(this.rootURL + '/AvioCompanies/1').subscribe(x => this.tempUser.aviocompany = x)
      console.log(this.tempUser)
      this.userSource.next(this.tempUser);
      this.UserToStorage(this.tempUser);
    }
    else
    {
    this.tempUser.type = type;
    this.userSource.next(this.tempUser);
    this.UserToStorage(this.tempUser);
    }
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
    const user1 = new User(2, "Ime", "Prezime", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");
    const user2 = new User(3, "TempIme", "TempPrezime", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");
    const user3 = new User(4, "Milan", "Milanovic", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");
    const user4 = new User(5, "adfg", "gdsg", "user123", "nebitno", "adresa", "user", "email@gmail.com", "02151240");

    friendList.push(user1);
    friendList.push(user2);
    friendList.push(user3);
    friendList.push(user4);

    return friendList;
  }

  postUser(user:User)
  {
    return this.http.post(this.rootURL + '/Users', user)
  }


  getUsersFromDb(): Observable<User[]>{
    return this.http.get<User[]>(this.rootURL + '/Users');
  }

  postFriend(user1:User, user2:User)
  {
    var users: User[] = new Array(user1, user2);
    console.log(users)  
    return this.http.post(this.rootURL + '/Friends', users);
  }

  getRequestsFromDb(currentUser: User): Observable<User[]>
  {
    let params = new HttpParams();
    params = params.append('var1', currentUser.id.toString());
    return this.http.get<User[]>(this.rootURL + '/Friends/Requests', {params : params});
  }

  getFriends(currentUser:User): Observable<any[]>
  {
    let params = new HttpParams();
    params = params.append('var1', currentUser.id.toString());
    return this.http.get<any[]>(this.rootURL + '/Friends', {params : params});
  }

  acceptFriend(id1:number, id2: number)
  {
    return this.http.get(this.rootURL + '/Friends/Accept/' + id1 + "/" + id2)
  }

  removeFriend(id1:number, id2: number)
  {
    return this.http.get(this.rootURL + '/Friends/Remove/' + id1 + "/" + id2)
  }
}
