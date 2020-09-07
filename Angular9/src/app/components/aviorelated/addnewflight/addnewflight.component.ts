import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-addnewflight',
  templateUrl: './addnewflight.component.html',
  styleUrls: ['./addnewflight.component.css']
})
export class AddnewflightComponent implements OnInit {

  private id: number;
  constructor() { 
     this.id = window.history.state.navigationId
  }

  ngOnInit(): void {
  }

}
