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
    nameticket:[''],
    numberTicket:[''],
      asunto:[''],
      solicitante:[''],
      fecha:[''],
      historial:this.formB.array([]),
  });

  registroUser= this.formB.group({
    asunto:['',Validators.required] ,

    persona_solicitante:['',Validators.required] ,
    descripcion_de_licencia:['',Validators.required] ,
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
   if (this.formTicket.value.solicitante === null || this.formTicket.value.solicitante  === '' ) {
     this.formTicket.controls.solicitante.setValue(ticket?.persona_solicitante);
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
