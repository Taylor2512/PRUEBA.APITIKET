import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiRoute } from 'src/app/Shared/Route/ApiRoute';
import { Ticket } from '../Model/TicketDto';
@Injectable({
  providedIn: 'root',
})
export class TicketServices{
  private urlApi = ApiRoute.UrlBase;
  private url = ApiRoute.Ticket; //URL API  tiket
   constructor(private http: HttpClient) {}

   putTicket(form: Ticket): Observable<any> {
    return this.http.put<any>(
      `${this.urlApi}${this.url}`,
      form
    );
  }
  GetDataTicket(query?:string): Observable<any> {
    if(query!=null){
      return this.http.get<any>(`${this.urlApi}${this.url}${query}`);

    }
    return this.http.get<any>(`${this.urlApi}${this.url}`);
  }
  PostTicket(form: Ticket): Observable<any> {
    return this.http.post<any>(
      `${this.urlApi}${this.url}`,
      form
    );
  }
}
