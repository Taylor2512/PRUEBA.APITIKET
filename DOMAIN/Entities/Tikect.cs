using DOMAIN.Helper.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    public class Tikect : DatosSeguridad
    {
        public Tikect(Guid id) : base(id)
        {
        }
         
        public string nameTicket { get; set; }

        public long numberTicket { get; set; }
        public string asunto { set; get; }
        public string persona_solicitante { set; get; }
        public string descripcion_de_licencia { set; get; }
        public List<Historial> historial { set; get; }



    }
}
