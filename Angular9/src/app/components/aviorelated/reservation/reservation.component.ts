import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { CountriesService } from 'src/app/services/countries.service';
import { UserService } from 'src/app/services/user.service';
import { Flight } from 'src/entities/flight';
import { Seat } from 'src/entities/seat';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  closeResult: string;

  flight: any;
  flight2
  counter = 0
  seat;
  searchText
  constructor(private modalService: NgbModal, private router: Router, private fb: FormBuilder, private route: ActivatedRoute, private data: AviocompanyService, public userservice: UserService, private avioCompanyService: AviocompanyService, private countryservice: CountriesService) {
    this.flight = window.history.state.example
  }

  ngOnInit(): void {
  }

  open(content, seat) {
    if (seat.Reserved === true) {
      this.seat = seat
      this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }
    else
      this.seat = undefined
  }

  Invite(user)
  {
    
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

}
