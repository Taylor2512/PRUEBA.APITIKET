import { Injectable, Input } from "@angular/core";
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { Ticket } from "../../Model/TicketDto";

@Injectable({ providedIn: 'root' })
export class BuscadorFrom{

  constructor(public formB: FormBuilder,) {}

  obtenerBuscador= this.formB.group({
    fechaini:[''],
    fechaFinal:[''],
    Foruser:['']

  });
}
