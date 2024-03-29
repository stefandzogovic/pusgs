import { Component, OnInit } from '@angular/core';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { AvioCompan } from 'src/entities/aviocompany';

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

  aviocompany: AvioCompan; 

  constructor(private data: AviocompanyService) { 
    this.aviocompany = data.aviocompanies[0];
    console.log(this.aviocompany);
  }

  ngOnInit(): void {
    navigator.geolocation.getCurrentPosition(position => {
      this.center = {
        lat: position.coords.latitude,
        lng: position.coords.longitude,
      }
    })
  }

}
