import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyProfileComponent } from './components/my-profile/my-profile.component';
import { AvioadminGuard, } from './guards/avioadmin.guard';
import { FriendlistComponent } from './components/friendlist/friendlist.component';
import { AvioprofileComponent } from './components/aviorelated/avioprofile/avioprofile.component';
import { AddnewdestinationComponent } from './components/aviorelated/addnewdestination/addnewdestination.component';
import { EditflightComponent } from './components/aviorelated/editflight/editflight.component';

const routes: Routes = [
  {path: '', component: HomeComponent },
  {
    path: 'profile',
    children: [
      {path: "", component: MyProfileComponent },
      {path: "friends", component: FriendlistComponent}
    ],
  },
  {
    canActivate: [AvioadminGuard],
    path:
     'avioprofile',
    children: [
      { path: "", component: AvioprofileComponent},
      { path: "editflight/:id", component: EditflightComponent},
      { path: "newdestination", component: AddnewdestinationComponent}
    ],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [HomeComponent, MyProfileComponent, AvioprofileComponent, EditflightComponent, FriendlistComponent]
