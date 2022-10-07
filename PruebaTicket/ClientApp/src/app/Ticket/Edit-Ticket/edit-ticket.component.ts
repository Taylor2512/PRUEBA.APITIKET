import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { Ticket } from '../Model/TicketDto';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { BaseFormTicket } from './Model/baseFormTicket';
import { pipe } from 'rxjs';
import { TicketServices } from '../Service/TickectService';
import { Router } from '@angular/router';
import { ApiRoute } from 'src/app/Shared/Route/ApiRoute';

@Component({
  selector: 'app-edit-ticket',
  templateUrl: './edit-ticket.component.html',
  styleUrls: ['./edit-ticket.component.css']
})
export class EditTicketComponent implements OnInit {

  @Input()ticket?:Ticket;
   constructor(public formB: BaseFormTicket,
    private router: Router,

    private apiServi:TicketServices) {   }

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


  this.formB.validatData(ticket);
   this.PutTicket();
   this.formB.setearValores();
    window.location.reload();
   }
   PutTicket() {
    const form: Ticket = this.formB.formTicket.value;
       this.apiServi.putTicket(form).subscribe((res: any) => {
        window.location.reload();


     });
  }
  eliminarArray(i:number){
    this.formB.removeItems(i);
  }

}
