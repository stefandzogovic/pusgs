import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ReservationService } from 'src/app/services/reservation.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-myreservations',
  templateUrl: './myreservations.component.html',
  styleUrls: ['./myreservations.component.css']
})
export class MyreservationsComponent implements OnInit {

  todaysDate
  myreservations;
  username
  constructor(private route: ActivatedRoute, private userservice: UserService, private res: ReservationService) {
    this.route.paramMap.subscribe(
      (params: ParamMap) => {
        this.username = params.get('username');
        res.getReservations(this.username).subscribe(
          x => {
            console.log(x)
            this.myreservations = x

          }
        )
      }
    )
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    this.todaysDate = yyyy + '-' + mm + '-' + dd;
  }

  ngOnInit(): void {

  }

}
