import { Injectable, Injector, TemplateRef, Type } from '@angular/core';
import { Overlay, OverlayConfig } from '@angular/cdk/overlay';
import { MyOverlayRef } from '../components/my-profile/myoverlayref';
import { ComponentPortal, PortalInjector } from '@angular/cdk/portal';
import { FriendlistComponent } from '../components/friendlist/friendlist.component';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ReservationService {

    readonly rootURL = 'http://localhost:51185/api'

    constructor(private http: HttpClient, private overlay: Overlay, private injector: Injector) {}

    sendEmail(seat, user)
    {
        return this.http.post(this.rootURL +'/Rerservations/sendemail/user/' + user.Id , seat).subscribe()
    }

    getReservation(username, seatid)
    {
      return this.http.get(this.rootURL +'/Rerservations/PostReservation/' + username + "/" + seatid)
    }

    getReservations(username)
    {
      console.log(username)
      return this.http.get(this.rootURL +'/Rerservations/GetReservations/' + username);

    }
    
  }