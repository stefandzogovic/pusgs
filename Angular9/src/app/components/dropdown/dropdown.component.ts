import { Component, OnInit } from '@angular/core';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent implements OnInit {

  stateInfo: any[] = [];
  countryInfo: any[] = [];
  cityInfo: any[] = [];

  constructor(private country:CountriesService) { }

  ngOnInit() {
    this.getCountries();
  }


  getCountries(){
    this.country.allCountries().
    subscribe(
      data2 => {
        this.countryInfo=data2;
        console.log('Data:', this.countryInfo);
      },
      err => console.log(err),
    )
  }

  onChangeCountry(countryValue) {
    this.stateInfo=this.countryInfo[countryValue].states;
    this.cityInfo=this.stateInfo[0].Cities;
  }

  onChangeState(stateValue) {
    this.cityInfo=this.stateInfo[stateValue].cities;
  }
    

}
