import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyProfileComponent } from './components/my-profile/my-profile.component';
import { AvioprofileComponent } from './components/avioprofile/avioprofile.component';

const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'profile', component: MyProfileComponent},
  {path: 'avioprofile', component: AvioprofileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [HomeComponent, MyProfileComponent, AvioprofileComponent]
