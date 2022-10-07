import { HttpClient } from '@angular/common/http';
import { Component,OnInit, Inject } from '@angular/core';
import { ApiRoute } from 'src/app/Shared/Route/ApiRoute';
import { BuscadorFrom } from '../Edit-Ticket/Model/buscadorFrom';
import { Ticket } from '../Model/TicketDto';
import { TicketServices } from '../Service/TickectService';


@Component({
  selector: 'app-list-ticket',
  templateUrl: './list-ticket.component.html',
  styleUrls: ['./list-ticket.component.css']
})
export class ListTicketComponent implements OnInit {

  items: Ticket[] = [];
  ticket?:Ticket;
  buscadores:any;
  fecha1:any;
  fechafin:any;
  constructor(http: HttpClient,
    public formB:BuscadorFrom,
    private apiServi:TicketServices) {

   this. getDataTicket();

   }
  ngOnInit(): void {
    this.getDataTicket();
  }

  GetDataForName(query?:string){
    this.apiServi.GetDataTicket(query).subscribe((res: Ticket[]) => {
      this.items = res;

     // this.formB.TickectService.setValue({ ...res });
    });
  }
  getDataTicket(){
    this.apiServi.GetDataTicket().subscribe((res: Ticket[]) => {
      this.items = res;

     // this.formB.TickectService.setValue({ ...res });
    });
   }
   buscar(){

    if(this.formB.obtenerBuscador.value.Foruser!=null&&this.formB.obtenerBuscador.value.Foruser!=''){
      this.buscadores=this.formB.obtenerBuscador.value.Foruser
      this.GetDataForName('?usuario='+this.buscadores)
      console.log(this.buscadores)
    }else{
      this.GetDataForName();

    }
    if(this.formB.obtenerBuscador.value.fechaini!=''&&this.formB.obtenerBuscador.value.fechaFinal!=''){
      this.fecha1=this.formB.obtenerBuscador.value.fechaini
      this.fechafin=this.formB.obtenerBuscador.value.fechaini
      console.log(this.buscadores)
    }else{
      this.GetDataForName('?fechaini='+this.fecha1+'&fechaFinal='+this.fechafin)
      this.GetDataForName();

    }
   }

   displayStyle = "none";

   openPopup(ticket: Ticket) {
    this.ticket=ticket;

     this.displayStyle = "block";
   }
   closePopup() {
    this.ticket==null;
     this.displayStyle = "none";
   }
}
