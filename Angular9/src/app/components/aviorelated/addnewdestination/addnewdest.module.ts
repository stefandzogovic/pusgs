import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddnewdestinationComponent } from './addnewdestination.component';
import { DropdownComponent } from '../../dropdown/dropdown.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddnewdestinationComponent,
    DropdownComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  bootstrap: [AddnewdestinationComponent],
  providers: []
})
export class AddnewdestModule { }
