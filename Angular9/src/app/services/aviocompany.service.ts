import { Injectable, Input } from '@angular/core';
import { Flight } from 'src/entities/flight';
import { AvioCompan } from 'src/entities/aviocompany';
import { Destination } from 'src/entities/destinations';
import { HttpClient, HttpParams } from "@angular/common/http"
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/entities/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AviocompanyService {

  private Source;
  private Source2;

  aviocompany;
  @Input() aviocompanies;
  readonly rootURL = 'http://localhost:51185/api'


  constructor(private http: HttpClient) {

    // this.loadAvioCompany();
    this.Source = new BehaviorSubject<User>(this.aviocompany);
    this.aviocompany = this.Source.asObservable();
    this.getAvioCompanies()
    console.log(this.aviocompanies)
  }


  delFlight(flight)
  {
    return this.http.delete(this.rootURL + '/AvioCompanies/Flight/' + flight.FlightId)

  }

  getAvioCompanies()
  {
    this.http.get(this.rootURL +'/AvioCompanies').subscribe(res =>
      {
        this.aviocompanies = res
      }, err => {
        console.log(err)
      })
  }
  postDest(destination: Destination) {
    return this.http.post(this.rootURL + '/AvioCompanies/AddNewDestination/' + this.aviocompany.AvioCompanyId, destination)
  }

  putFlight(flight)
  {
    return this.http.put(this.rootURL + '/AvioCompanies/PutFlight/' + flight.FlightId, flight)
  }
  dellDest(destination)
  {
    return this.http.delete(this.rootURL + '/AvioCompanies/Destination/' + destination.DestinationId)
  }

  postFlight(id: number, flight: Flight)
  {
   var  x = this.http.post(this.rootURL + '/AvioCompanies/AddNewFlight/' + id, flight)
   this.Source.next(x)
   return x;
  }
}
