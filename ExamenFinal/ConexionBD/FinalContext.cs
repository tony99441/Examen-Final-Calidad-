using ExamenFinal.ConexionBD.Maps;
using ExamenFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.ConexionBD
{
    public class FinalContext : DbContext
    {
        public DbSet<Nota> notas { get; set; }
        public DbSet<Etiqueta> etiquetas { get; set; }
        public DbSet<DetalleNotaEtiqueta> DetalleNotaEtiquetas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NotaCompartida> NotaCompartidas { get; set; }
        public FinalContext(DbContextOptions<FinalContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DetalleNotaEtiquetaMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new EtiquetaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NotaCompartidaMap());

        }
    }
}