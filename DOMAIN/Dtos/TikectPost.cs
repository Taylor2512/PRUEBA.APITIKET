using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Dtos
{
    public class TikectPost
    {
      
        public string? asunto { set; get; }
        public string? persona_solicitante { set; get; }
        public string? descripcion_de_licencia { set; get; }
    }
    public class TikectPut
    {
      public Guid id { set; get; }  
        public string? asunto { set; get; }
        public string? persona_solicitante { set; get; }
        public string? descripcion_de_licencia { set; get; }
        public string? nameTicket { get; set; } = "CTE";

     
        public List<HistorialPut?>? historial { set; get; }
    }

    public class HistorialPut
    {

        public string usuario_soporte { set; get; }
        public string comentario_trabajo_realizado { set; get; }
        public Guid? id_Ticket { set; get; }
    }
}
