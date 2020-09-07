import { Component, OnInit } from '@angular/core';
import { CountriesService } from 'src/app/services/countries.service';
import { Destination } from 'src/entities/destinations';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-addnewdestination',
  templateUrl: './addnewdestination.component.html',
  styleUrls: ['./addnewdestination.component.css']
})
export class AddnewdestinationComponent implements OnInit {

  countryInfo1
  cityInfo1: any[] = [];
  countryInfo2
  cityInfo2: any[] = [];
  CountryCity: Array<any> = ["-1", "-1", "-1", "-1"]

  constructor(private country: CountriesService, private service: AviocompanyService, private userservice: UserService) { }

  ngOnInit() {
    this.getCountries();
  }


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

  btnAddNewDest() {
    console.log(this.countryInfo1)
    var destination = new Destination(this.CountryCity[0].type + '|' + this.CountryCity[1], this.CountryCity[2].type + '|' + this.CountryCity[3])

    this.service.postDest(destination).subscribe(
      res => {
        this.userservice.currentUser.source.value.aviocompany.Destinations.push(res)
      },
      err => {
        console.log(err)
      })
  }

}
