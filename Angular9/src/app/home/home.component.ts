import { Component, OnInit } from '@angular/core';
import { element } from 'protractor';
import { User } from 'src/entities/user';
import { AviocompanyService } from '../services/aviocompany.service';
import { CountriesService } from '../services/countries.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private country: CountriesService, public avioservice: AviocompanyService) {
    // if (avioservice) {
    //   this.avioservice.aviocompanies.forEach(element1 => {
    //     element1.Destinations.forEach(element2 => {
    //       element2.Flights.forEach(element3 => {
    //         this.flights.push(element3)
    //       });
    //     });
    //   });
    // }

  }
  Dtaasc
  Dtadescend
  countryInfo1
  cityInfo1: any[] = [];
  countryInfo2
  cityInfo2: any[] = [];
  CountryCity: Array<any> = ["-1", "-1", "-1", "-1"]
  searchText: string;
  sortby: string = '';
  order: string = 'asc';
  firstclick: boolean = false
  flights = []
  Baggage
  People

  getCountries() {
    this.country.allCountries().
      subscribe(
        data2 => {
          this.countryInfo1 = Object.keys(data2).map(key => ({ type: key, value: data2[key] }));
          this.countryInfo2 = this.countryInfo1
        },
        err => console.log(err),
      )
  }

  onChangeCountry1(countryValue) {
    this.cityInfo1 = countryValue.value
  }

  onChangeCountry2(countryValue) {
    this.cityInfo2 = countryValue.value
  }


  SortBy(sortby: string) {
    this.sortby = sortby
  }

  sort(order: string) {
    this.order = order
    if (this.sortby == 'Name') {
      if (this.order === 'asc') {
        this.avioservice.aviocompanies.sort((a, b) => (a.Name > b.Name) ? 1 : -1)

      }
      else if (this.order === 'desc') {
        this.avioservice.aviocompanies.sort((a, b) => (a.Name > b.Name) ? -1 : 1)

      }
    }
    else if (this.sortby == 'City') {
      if (this.order === 'asc') {
        this.avioservice.aviocompanies.sort((a, b) => (a.Address > b.Name) ? 1 : -1)

      }
      else if (this.order === 'desc') {
        this.avioservice.aviocompanies.sort((a, b) => (a.Name > b.Name) ? -1 : 1)

      }
    }
  }

  Search() {
    var asc = this.CountryCity[0] + '|' + this.CountryCity[1]
    var desc = this.CountryCity[1] + '|' + this.CountryCity[2]
    console.log(this.Dtaasc)
    this.avioservice.aviocompanies.forEach(element1 => {
      element1.Destinations.forEach(element2 => {
        if (element2.Ascenddest == asc || element2.Descenddest == desc) {
          

          element2.Flights.forEach(element3 => {
          });
        }
      });
    });
  }
  ngOnInit(): void {
    this.getCountries()
  }

}
