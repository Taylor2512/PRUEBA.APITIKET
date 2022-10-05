using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Interfaces.Config
{
    internal interface IConfigticket: 
        IEntityTypeConfiguration<Tikect>,
        IEntityTypeConfiguration<Historial>
    {
    }
}
