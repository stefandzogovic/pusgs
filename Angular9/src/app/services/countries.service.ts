import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import data from './countries.json'

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  url :string = './countries.json'

  constructor(private http:HttpClient) { }
  allCountries(): Observable<any>{
    return this.http.get<any>("/assets/countries.json");
  }
}
