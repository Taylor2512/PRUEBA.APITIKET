import { Component, OnInit } from '@angular/core';
import { BaseFormTicket } from '../edit-ticket/Model/baseFormTicket';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Ticket } from '../Model/TicketDto';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.css']
})
export class CreateTicketComponent implements OnInit {

  constructor(public formB: BaseFormTicket) { }
  registrar?:Ticket;
  prieto?:string;

  ngOnInit(): void {
  }

  btnGuardar(){
    console.log(this.registrar?.asunto);

    console.log(this.prieto);
  }
}
