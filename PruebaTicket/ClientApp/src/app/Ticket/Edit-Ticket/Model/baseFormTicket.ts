import { Injectable, Input } from "@angular/core";
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { Ticket } from "../../Model/TicketDto";

@Injectable({ providedIn: 'root' })

export class BaseFormTicket{

  constructor(private formB: FormBuilder,) {


  }
  ticket?:Ticket;
  formTicket=this.formB.group({

      nameticket:[this.ticket?.nameTicket],
      asunto:[''],
      solicitante:[''],
      fecha:[''],
      detallle:this.formB.array([]),
  });



  get getDetalleTicket(){

    return this.formTicket.get('detallle') as FormArray;
  }


  setFormulario(ticket?:Ticket){
    let form =this.formB.group({
      usuario_soporte:[ticket?.persona_solicitante],
      comentario_trabajo_realizado:[''],
      asunto:[ticket?.asunto],
      nameticket:[ticket?.nameTicket+'-'+ticket?.numberTicket],
     })

    this.getDetalleTicket.push(form);

  }

  removeItems(i:number){
    this.getDetalleTicket.removeAt(i);
  }
}
