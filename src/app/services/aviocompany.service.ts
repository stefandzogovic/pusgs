import { Injectable } from '@angular/core';
import { Flight } from 'src/entities/flight';
import { AvioCompan } from 'src/entities/aviocompany';
import { Destination } from 'src/entities/destinations';

@Injectable({
  providedIn: 'root'
})
export class AviocompanyService {

  aviocompanies = new Array<AvioCompan>();
  
  constructor()
   { 
     this.loadAvioCompany();
   }

  loadAvioCompany()
  {
      const stops1 = ['Nedodjija'];
      const stops2 = ['Ne znam', 'Negde', 'Daleko'];
      const flight1 = this.loadFlight(new Date('December 17, 1995 03:24:00').toUTCString(), new Date('December 17, 1995 06:24:00').toUTCString(), 3, 450, 300, stops1);
      const flight2 = this.loadFlight(new Date('December 18, 1995 19:00:00').toUTCString(), new Date('December 19, 1995 00:56:00').toUTCString(), 5.56, 1000, 100, stops2);
      const flightarray = new Array<Flight>();
      flightarray.push(flight1);
      flightarray.push(flight2);
      const dest = new Destination("BEG", "BUD", flightarray);
      const dest2 = new Destination("BEG", "LDN", null);
      const destarray = new Array<Destination>();
      destarray.push(dest);
      destarray.push(dest2);
      const tempaviocomp = new AvioCompan('Klisa Airlines', 'Prevozimo ljude za male pare preko sveta.', destarray);
      this.aviocompanies.push(tempaviocomp);

  }

  loadFlight(dtascend: string, dtdescend: string, duration: number, distance: number, ticketprice: number, stops: Array<string>)
  {
     const tempflight = new Flight(dtascend, dtdescend, duration, distance, ticketprice, stops);
     return tempflight;
  }
}
