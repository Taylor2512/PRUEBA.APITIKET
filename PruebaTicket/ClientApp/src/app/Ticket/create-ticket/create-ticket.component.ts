import { Component, OnInit } from '@angular/core';
import { BaseFormTicket } from '../edit-ticket/Model/baseFormTicket';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Ticket } from '../Model/TicketDto';
import { TicketServices } from '../Service/TickectService';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.css']
})
export class CreateTicketComponent implements OnInit {

  constructor(public formB: BaseFormTicket,private apiServi:TicketServices) { }
  registrar?:any;
  prieto?:string;

  ngOnInit(): void {
  }

  PostTicket() {
    const form: Ticket = this.formB.registroTickets.value;
    nameTicket:String
    this.apiServi.PostTicket(form).subscribe((res: any) => {
      nameTicket:res.nameTicket,
      this.registrar=res.nameTicket+'-'+res.numberTicket;
    });
  }
  btnGuardar(){

   this. PostTicket();
   window.location.reload();
  }
}
