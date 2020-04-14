import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { Flight } from 'src/entities/flight';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { AvioCompan } from 'src/entities/aviocompany';

@Component({
  selector: 'app-editflight',
  templateUrl: './editflight.component.html',
  styleUrls: ['./editflight.component.css']
})
export class EditflightComponent implements OnInit {

  id: number;
  flight;
  constructor(private route: ActivatedRoute, private data: AviocompanyService) {
    route.params.subscribe(params => { this.id = params['id']; });

    console.log(data.aviocompanies);
    console.log(this.id);
    this.flight = this.data.aviocompanies[0].destinations[0].flights.find(x => x.id.toString() === this.id.toString());
    console.log(this.flight);

  }

  ngOnInit(): void {
  }

}
