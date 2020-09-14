import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyProfileComponent } from './components/my-profile/my-profile.component';
import { AvioadminGuard, } from './guards/avioadmin.guard';
import { FriendlistComponent } from './components/friendlist/friendlist.component';
import { AvioprofileComponent } from './components/aviorelated/avioprofile/avioprofile.component';
import { AddnewdestinationComponent } from './components/aviorelated/addnewdestination/addnewdestination.component';
import { EditflightComponent } from './components/aviorelated/editflight/editflight.component';
import { AddnewflightComponent } from './components/aviorelated/addnewflight/addnewflight.component';
import { ReservationComponent } from './components/aviorelated/reservation/reservation.component';
import { AcceptreservationComponent } from './components/aviorelated/acceptreservation/acceptreservation.component';
import { MyreservationsComponent } from './components/aviorelated/myreservations/myreservations.component';
import { ProfileGuard } from './guards/profile.guard';

const routes: Routes = [
  {path: '', component: HomeComponent },
  {
    canActivate: [ProfileGuard],
    path: 'profile/:username',
    children: [
      {path: "", component: MyProfileComponent },
      {path: "friends", component: FriendlistComponent},
      {path: "acceptInvitation/seat/:id", component: AcceptreservationComponent},
      {path: "MyReservations", component: MyreservationsComponent}
    ],
  },
  {
    canActivate: [AvioadminGuard],
    path:
     'avioprofile',
    children: [
      { path: "", component: AvioprofileComponent},
      { path: "destination/:id/editflight/:id", component: EditflightComponent},
      { path: "newdestination", component: AddnewdestinationComponent},
      {path: "destination/:id/addnewflight", component: AddnewflightComponent}
    ],
  },
  { path: 'aviocompany/:id', component:AvioprofileComponent},
  { path: 'reserve/flight/:id', component:ReservationComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [HomeComponent, MyProfileComponent, AvioprofileComponent, EditflightComponent, FriendlistComponent, MyreservationsComponent]
