import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { Ticket } from '../Model/TicketDto';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { BaseFormTicket } from './Model/baseFormTicket';

@Component({
  selector: 'app-edit-ticket',
  templateUrl: './edit-ticket.component.html',
  styleUrls: ['./edit-ticket.component.css']
})
export class EditTicketComponent implements OnInit {

  @Input()ticket?:Ticket;
  constructor(    public formB: BaseFormTicket,


    ) {


this.formB.ticket=this.ticket;
   }

   @Input('init')
   count: number = 0;

   increment() {
    this.formB.ticket=this.ticket;

    this.formB.setFormulario(this.ticket);
   }

   decrement() {
     this.count--;
   }
  ngOnInit(): void {
    this.formB.ticket=this.ticket;
    this.formB.setFormulario(this.ticket);


   }

  displayStyle = "none";

  SucesDetalle() {
    this.displayStyle = "block";
  }
  closeDetalle() {
    this.displayStyle = "none";
  }

  eliminarArray(i:number){
    this.formB.removeItems(i);
  }

}
