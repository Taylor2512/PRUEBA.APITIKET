using DOMAIN.Entities;
using DOMAIN.Helper.Enums;
using DOMAIN.Helper.Query;
using INFRASTRUCTURE.Interfaces.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Config
{
    internal class ConfigTicket : IConfigticket
    {
        public void Configure(EntityTypeBuilder<Tikect> builder)
        {
            builder.ToTable(NameTbl.tbl_ticket.ToString());
            builder.HasIndex(e => e.numberTicket)
                .HasDatabaseName("UX_IDTypes_numberTicket");
            builder.Property(e => e.numberTicket).UseMySqlIdentityColumn();
         
            builder.Property(e => e.feca_de_ingreso).HasDefaultValueSql(constantsSql.FecaDefault);
            builder.Property(e => e.fecha_modificado).HasDefaultValueSql(constantsSql.FechaUpdate);
            builder.HasMany(e => e.historial).WithOne(e => e.Tikect).HasForeignKey(e => e.id_Ticket).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_ticket_histrial");
        }

        public void Configure(EntityTypeBuilder<Historial> builder)
        {
            builder.ToTable(NameTbl.tbl_historial.ToString());
            builder.Property(e => e.feca_de_ingreso).HasDefaultValueSql(constantsSql.FecaDefault);
            builder.Property(e => e.fecha_modificado).HasDefaultValueSql(constantsSql.FechaUpdate);
        }
    }
}
