import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'
import { Flight } from 'src/entities/flight';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { AvioCompan } from 'src/entities/aviocompany';
import { UserService } from 'src/app/services/user.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-editflight',
  templateUrl: './editflight.component.html',
  styleUrls: ['./editflight.component.css']
})
export class EditflightComponent implements OnInit {

  selected;
  flightId;
  destinationId: number;
  flight;
  dropdownSettings;
  dropdownList = []
  Dtaascend
  Dtadescend
  Ticketprice
  placeholderlist = []
  Distance
  Seats

  constructor(private router: Router, private fb: FormBuilder, private route: ActivatedRoute, private data: AviocompanyService,  private userservice: UserService, private avioCompanyService: AviocompanyService, private countryservice: CountriesService) {
    route.params.subscribe(params => { this.flightId = params['id']; });
    let destination = window.history.state.example
    this.flight = destination.Flights.find(x => x.FlightId === parseInt(this.flightId))
    this.Dtaascend = this.flight.Dtaascend
    this.Dtadescend = this.flight.Dtadescend
    this.Ticketprice = this.flight.Ticketprice
    this.Distance = this.flight.Distance
    this.Seats = this.flight.Seats
    console.log(this.flight)
    for (let index = 0; index < this.flight.Stops.length; index++) {
      let x = this.dropdownList.find(x => x.item_text === this.flight.Stops[0].City)
     }
  }

  getData(): void {
    let tmp = [];
    this.countryservice.allCountries().subscribe(data => {
      data = Object.keys(data)
      for (let i = 0; i < data.length; i++) {
        tmp.push({ item_id: i, item_text: data[i] });
      }

      this.dropdownList = tmp;
      for (let index = 0; index < this.flight.Stops.length; index++) {
        let x = this.dropdownList.find(x => x.item_text === this.flight.Stops[index].City)
        this.placeholderlist.push(x)
      }
    });
  }

  onSelected($event) {

    this.selected = $event;
  }

  onSubmit() {


    this.flight.Dtaascend = this.Dtaascend
    this.flight.Dtadescend = this.Dtadescend
    this.flight.Ticketprice = this.Ticketprice
    this.flight.Distance = this.Distance
    this.flight.Seats = this.Seats

    this.avioCompanyService.putFlight(this.flight).subscribe(data2 => {
    
      
      var index = this.userservice.currentUser.source.value.aviocompany.Destinations.find(i => i.DestinationId === this.flight.DestinationId).Flights.find(x => x.FlightId === this.flight.FlightId)
      var indexx = this.userservice.currentUser.source.value.aviocompany.Destinations.find(i => i.DestinationId === this.flight.DestinationId).Flights.indexOf(index)
      this.userservice.currentUser.source.value.aviocompany.Destinations.find(i => i.DestinationId === this.flight.DestinationId).Flights[indexx] = this.flight
      this.router.navigateByUrl('/avioprofile')}
    )

  }

  ngOnInit(): void {
    this.getData()


    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }
  

}
