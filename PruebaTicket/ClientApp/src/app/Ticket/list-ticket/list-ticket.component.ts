import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ApiRoute } from 'src/app/Shared/Route/ApiRoute';
import { Ticket } from '../Model/TicketDto';

@Component({
  selector: 'app-list-ticket',
  templateUrl: './list-ticket.component.html',
  styleUrls: ['./list-ticket.component.css']
})
export class ListTicketComponent {

  items: Ticket[] = [];
  ticket?:Ticket;

  constructor(http: HttpClient,) {
    http.get<Ticket[]>(ApiRoute.UrlBase + ApiRoute.Ticket).subscribe(result  => {
      this.items = result;
    }, error => console.error(error));


   }

   displayStyle = "none";

   openPopup(ticket: Ticket) {
    this.ticket=ticket;
     console.log(ticket.asunto);

     this.displayStyle = "block";
   }
   closePopup() {
     this.displayStyle = "none";
   }
}
