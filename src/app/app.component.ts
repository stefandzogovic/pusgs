import { Component } from '@angular/core';
import {Router} from '@angular/router';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'pusgs-front';
  constructor(
    private router: Router,
    private userService: UserService
   ) {}

  becomeSomething(param : string): void {
    this.userService.changeType(param);
    console.log(this.userService.currentUser);
    this.router.navigate(['/']);
  }

  revertRole(): void {
    this.userService.changeType("guest");
    this.router.navigate(['/']); 
  }
}
