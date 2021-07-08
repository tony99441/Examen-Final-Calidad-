using ExamenFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.ConexionBD.Maps
{
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Nota");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.detalleNotaEtiquetas).
                WithOne(o => o.nota).
                HasForeignKey(o => o.IdNota);

        }
    }
}
