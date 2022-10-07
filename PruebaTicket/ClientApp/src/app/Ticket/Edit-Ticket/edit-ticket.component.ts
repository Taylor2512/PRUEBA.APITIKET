import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { Ticket } from '../Model/TicketDto';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { BaseFormTicket } from './Model/baseFormTicket';
import { pipe } from 'rxjs';

@Component({
  selector: 'app-edit-ticket',
  templateUrl: './edit-ticket.component.html',
  styleUrls: ['./edit-ticket.component.css']
})
export class EditTicketComponent implements OnInit {

  @Input()ticket?:Ticket;
   constructor(public formB: BaseFormTicket,) {   }

    @Input('init')
   count: number = 0;
 bandera:boolean=false;
   increment() {

    this.formB.setFormulario();
    console.log( "sdsd")
   }

   decrement() {
     this.count--;
   }
  ngOnInit(): void {
this.formB.setearValores();
   }

  displayStyle = "none";

  SucesDetalle() {
    this.displayStyle = "block";
  }
  closeDetalle() {
    this.displayStyle = "none";
  }

  public  validarValores() {
    if (this.formB.formTicket.value.asunto === null || this.formB.formTicket.value.asunto  === '' ) {
        console.log('estan vacios');
      }else{
        console.log('esta lleno');

      }
  }
  getData(ticket?: Ticket){

    // this.formB.formTicket.controls.asunto.setValue(ticket?.asunto);
    // this.formB.formTicket.controls.solicitante.setValue(ticket?.persona_solicitante);

    // console.log('dd')
    // console.log(ticket?.asunto)
   this.formB.validatData(ticket);

   }


  eliminarArray(i:number){
    this.formB.removeItems(i);
  }

}
