import { Component, OnInit, TemplateRef } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from 'src/app/services/user.service';
import { ComponentType } from '@angular/cdk/portal';
import { OverlayService } from 'src/app/services/overlay.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {

  currentUser : User;
  routerLinkFriends;
  constructor(private data: UserService) {}


  ngOnInit(): void {
    this.data.currentUser.subscribe(user => this.currentUser = user)
    this.routerLinkFriends = this.currentUser.username  + "/friends"; 

  }

//   open(content: TemplateRef<any> | ComponentType<any> | string) {
//     const ref = this.overlayService.open(content, null);
//  }

}
