import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { HttpClientModule} from "@angular/common/http"

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import {GoogleMapsModule} from '@angular/google-maps';
import { UserService } from './services/user.service';
import { FriendlistComponent } from './components/friendlist/friendlist.component';
import { CountriesService } from './services/countries.service';
import { AddnewdestModule } from './components/aviorelated/addnewdestination/addnewdest.module';
import { AddnewflightComponent } from './components/aviorelated/addnewflight/addnewflight.component';
import { OverlayModule } from '@angular/cdk/overlay';


@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    HeaderComponent,
    FooterComponent,
    FriendlistComponent,
    AddnewflightComponent
  ],
  imports: [
    BrowserModule,
    OverlayModule,
    AddnewdestModule,
    AppRoutingModule,
    FormsModule, ReactiveFormsModule,
    Ng2SearchPipeModule,
    GoogleMapsModule,
    HttpClientModule
  ],
  bootstrap: [AppComponent],
  providers: [UserService, CountriesService]

})
export class AppModule { }
