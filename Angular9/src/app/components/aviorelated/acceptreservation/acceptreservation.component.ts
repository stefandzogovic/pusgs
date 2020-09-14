import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-acceptreservation',
  templateUrl: './acceptreservation.component.html',
  styleUrls: ['./acceptreservation.component.css']
})
export class AcceptreservationComponent implements OnInit {

  constructor(private route: ActivatedRoute, private reservationsservice: ReservationService) { }

  seatid
  username
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params: ParamMap) => {
        this.seatid = params.get('id');
        this.username = params.get('username');
      }
    )
  }

  Accept()
  {
    this.reservationsservice.getReservation(this.username, this.seatid).subscribe()
    {

    }
  }

  Decline()
  {

  }

}
