import { Component, OnInit } from '@angular/core';
import { AviocompanyService } from 'src/app/services/aviocompany.service';
import { AvioCompan } from 'src/entities/aviocompany';

@Component({
  selector: 'app-avioprofile',
  templateUrl: './avioprofile.component.html',
  styleUrls: ['./avioprofile.component.css']
})
export class AvioprofileComponent implements OnInit {

  aviocompany: AvioCompan;
  constructor(private data: AviocompanyService) { 
    this.aviocompany = data.aviocompanies[0];
    console.log(this.aviocompany);
  }


  ngOnInit(): void {
  }

}
