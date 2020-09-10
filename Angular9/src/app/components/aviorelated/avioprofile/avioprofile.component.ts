import { Component, OnInit } from '@angular/core';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { AvioCompan } from 'src/entities/aviocompany';
import { Destination } from 'src/entities/destinations';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-avioprofile',
  templateUrl: './avioprofile.component.html',
  styleUrls: ['./avioprofile.component.css']
})
export class AvioprofileComponent implements OnInit {

  zoom = 12
  center: google.maps.LatLngLiteral
  options: google.maps.MapOptions = {
    mapTypeId: 'hybrid',
    zoomControl: false,
    scrollwheel: false,
    disableDoubleClickZoom: true,
    maxZoom: 15,
    minZoom: 8,
  }
  aviocompany;
  
  constructor(private router: Router, private data: AviocompanyService, private userService: UserService) { 
    this.aviocompany = userService.currentUser.source.value.aviocompany
    data.aviocompany = this.aviocompany
  }

  ngOnInit(): void {
    navigator.geolocation.getCurrentPosition(position => {
      this.center = {
        lat: position.coords.latitude,
        lng: position.coords.longitude,
      }
    })
  }


  delete_flight(flight)
  {
    console.log(flight)
    this.data.delFlight(flight).subscribe(
      res => {
        this.aviocompany.Destinations.find(dest => dest.DestinationId === flight.DestinationId).Flights = this.aviocompany.Destinations.find(dest => dest.DestinationId === flight.DestinationId).Flights.filter(x => x !== flight)
      },
      err => {
        console.log(err)
      })
  }
  AddNewDestination(event:Event): void
  {
    this.router.navigateByUrl('avioprofile/newdestination')
  }

  deleteDestination(dest): void
  {
    this.data.dellDest(dest).subscribe(
      res => {
        this.aviocompany.Destinations = this.aviocompany.Destinations.filter(item => item !== dest)
      },
      err => {
        console.log(err)
      })
  }

  addFlight(dest): void
  {
    
  }

}

 