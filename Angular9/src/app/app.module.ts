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
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrderModule } from 'ngx-order-pipe';



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
    OrderModule,
    NgbModule,
    AddnewdestModule,
    NgMultiSelectDropDownModule.forRoot(),
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
