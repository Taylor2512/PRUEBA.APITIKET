
using DOMAIN.Helper.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    public class DatosSeguridad : Entity<Guid>
    {
      
        public DatosSeguridad(Guid id) : base(id)
        {
        }

        public DatosSeguridad()
        {
        }


        [Column(TypeName = "DATETIME")]
        public DateTime feca_de_ingreso { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime fecha_modificado { get; set; }
    }
}
