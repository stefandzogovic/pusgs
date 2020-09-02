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
import { DropdownComponent } from './components/dropdown/dropdown.component';


@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    DropdownComponent,
    HeaderComponent,
    FooterComponent,
    FriendlistComponent,
  ],
  imports: [
    BrowserModule,
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
