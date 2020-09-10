import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { CountriesService } from 'src/app/services/countries.service';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { Flight } from 'src/entities/flight';
import { Stop } from 'src/entities/stop';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Seat } from 'src/entities/seat';


@Component({
  selector: 'app-addnewflight',
  templateUrl: './addnewflight.component.html',
  styleUrls: ['./addnewflight.component.css']
})
export class AddnewflightComponent implements OnInit {

  private id: number;
  dropdownList = []
  flight: Flight = new Flight();
  selectedItems = []
  selected;
  dropdownSettings: IDropdownSettings;
  angForm: FormGroup;

  constructor(private fb: FormBuilder, private countryservice: CountriesService, private avioCompanyService: AviocompanyService, private userservice: UserService, private router: Router) {
    this.id = window.history.state.navigationId
    this.createForm()
    var x = ['A', 'B', 'C', 'D', 'E', 'F']
    var y = 0
    var z = 1
    for (let index = 1; index <= 60; index++) {
      if (index % 6 == 0) {
        this.flight.seats.push(new Seat(z.toString() + x[y]))
        z += 1
        y = 0

      }
      else {
        this.flight.seats.push(new Seat(z.toString() + x[y]))
        y += 1
      }

    }
  }

  createForm() {
    this.angForm = this.fb.group({
      Dtaascend: ['', Validators.required],
      Dtadescend: ['', Validators.required],
      Distance: ['', Validators.required],
      Ticketprice: ['', Validators.required]
    });
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

  onSelected($event) {

    this.selected = $event;
  }

  getData(): void {
    let tmp = [];
    this.countryservice.allCountries().subscribe(data => {
      data = Object.keys(data)
      for (let i = 0; i < data.length; i++) {
        tmp.push({ item_id: i, item_text: data[i] });
      }

      this.dropdownList = tmp;
    });
  }

  submitForm() {
    this.flight.dtaascend = this.angForm.value.Dtaascend
    this.flight.dtadescend = this.angForm.value.Dtadescend
    this.flight.distance = this.angForm.value.Distance
    this.flight.ticketprice = this.angForm.value.Ticketprice
    this.flight.stops.push(new Stop(this.selected.item_text))
    console.log(this.flight.seats);

    this.avioCompanyService.postFlight(this.id, this.flight).subscribe(data2 => {

      this.userservice.currentUser.source.value.aviocompany.Destinations.find(i => i.DestinationId == this.id).Flights.push(data2)
      this.router.navigateByUrl('/avioprofile')}
    )

  }
}
