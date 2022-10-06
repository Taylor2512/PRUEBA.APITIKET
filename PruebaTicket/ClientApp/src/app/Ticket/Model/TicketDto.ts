export interface Ticket{
  id?: string,
  nameTicket?: string,
  numberTicket?: number,
  asunto: string,
  persona_solicitante: string,
  descripcion_de_licencia: string,
  feca_de_ingreso: Date,
}
