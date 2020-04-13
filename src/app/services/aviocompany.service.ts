import { Injectable } from '@angular/core';
import { Flight } from 'src/entities/flight';
import { AvioCompan } from 'src/entities/aviocompany';

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
      const stops1 = ['Beograd', 'Sofija'];
      const stops2 = ['Ne znam', 'Negde', 'Daleko'];
      const flight1 = this.loadFlight(new Date('December 17, 1995 03:24:00'), new Date('December 17, 1995 06:24:00'), 3, 450, 300, stops1);
      const flight2 = this.loadFlight(new Date('December 18, 1995 19:00:00'), new Date('December 19, 1995 00:56:00'), 5.56, 1000, 467, stops2);
      const flightarray = new Array<Flight>();
      flightarray.push(flight1);
      flightarray.push(flight2);
      const tempaviocomp = new AvioCompan('Klisa Airlines', 'Prevozimo ljude za male pare preko sveta.', flightarray);
      this.aviocompanies.push(tempaviocomp);

  }

  loadFlight(dtascend: Date, dtdescend: Date, duration: number, distance: number, ticketprice: number, stops: Array<string>)
  {
     const tempflight = new Flight(dtascend, dtdescend, duration, distance, ticketprice, stops);
     return tempflight;
  }
}
