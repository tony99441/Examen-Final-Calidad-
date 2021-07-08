

    using ExamenFinal.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NotaCompartidaMap: IEntityTypeConfiguration<NotaCompartida>
    {
        public void Configure(EntityTypeBuilder<NotaCompartida> builder)
        {
            builder.ToTable("NotaCompartida");
            builder.HasKey(o => o.Id);

         

        }
    }
    
