import { Injectable, Input } from "@angular/core";
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { Ticket } from "../../Model/TicketDto";

@Injectable({ providedIn: 'root' })

export class BaseFormTicket{

  constructor(private formB: FormBuilder,) {


  }
  ticket?:Ticket;
  formTicket=this.formB.group({

    id:[''],
    nameTicket:[''],
    numberTicket:[''],
      asunto:[''],
      persona_solicitante:[''],
      descripcion_de_licencia:[''],
      fecha:[''],
      historial:this.formB.array([]),
  });

  registroTickets= this.formB.group({
    asunto:[''] ,

    persona_solicitante:['' ] ,
    descripcion_de_licencia:[''] ,
  });

  setearValores(){
    let form=this.formB.group({

      nameticket:[null],
      numberTicket:[null],
      asunto:[null,Validators.maxLength(10),
      Validators.minLength(5),
    ],
      solicitante:[null,Validators.maxLength(10),
      Validators.minLength(5)],
      fecha:[null],
   });
   this.formTicket.controls.asunto.setValue(null);

  }



  get getDetalleTicket(){

    return this.formTicket.get('historial') as FormArray;
  }

  validatData(ticket?:Ticket){
    if (this.formTicket.value.asunto === null || this.formTicket.value.asunto  === '' ) {
      this.formTicket.controls.asunto.setValue(ticket?.asunto);
   }
   if (this.formTicket.value.id === null || this.formTicket.value.id  === '' ) {
    this.formTicket.controls.id.setValue(ticket?.id);
 }
   if (this.formTicket.value.persona_solicitante === null || this.formTicket.value.persona_solicitante  === '' ) {
     this.formTicket.controls.persona_solicitante.setValue(ticket?.persona_solicitante);
   }
   if (this.formTicket.value.fecha === null || this.formTicket.value.fecha  === '' ) {
    this.formTicket.controls.fecha.setValue(ticket?.feca_de_ingreso);
 }
 if (this.formTicket.value.nameticket === null || this.formTicket.value.nameticket  === '' ) {
  this.formTicket.controls.nameticket.setValue(ticket?.nameTicket);
}
if (this.formTicket.value.numberTicket === null || this.formTicket.value.numberTicket  === '' ) {
  this.formTicket.controls.numberTicket.setValue(ticket?.numberTicket);
}
if (this.formTicket.value.descripcion_de_licencia === null || this.formTicket.value.descripcion_de_licencia  === '' ) {
  this.formTicket.controls.descripcion_de_licencia.setValue(ticket?.descripcion_de_licencia);
}

  }

  setFormulario(){
    let form =this.formB.group({
      usuario_soporte:[''],
      comentario_trabajo_realizado:[''],
       })

    this.getDetalleTicket.push(form);

  }

  removeItems(i:number){
    this.getDetalleTicket.removeAt(i);
  }
}
