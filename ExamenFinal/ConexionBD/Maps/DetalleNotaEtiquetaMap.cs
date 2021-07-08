using ExamenFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.ConexionBD.Maps
{
    public class DetalleNotaEtiquetaMap: IEntityTypeConfiguration<DetalleNotaEtiqueta>
    {
        public void Configure(EntityTypeBuilder<DetalleNotaEtiqueta> builder)
        {
            builder.ToTable("DetalleNotaEtiqueta");
            builder.HasKey(o => o.Id);


            builder.HasOne(o => o.nota).WithMany(o => o.detalleNotaEtiquetas).HasForeignKey(o => o.IdNota);
            builder.HasOne(o => o.etiqueta).WithMany(o => o.detalleNotaEtiquetas).HasForeignKey(o => o.IdEtiqueta);

        }
    }
}
