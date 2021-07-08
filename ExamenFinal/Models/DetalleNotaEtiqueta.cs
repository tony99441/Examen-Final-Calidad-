using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class DetalleNotaEtiqueta
    {
        public int Id { get; set; }

        public int IdNota { get; set; }
        public int IdEtiqueta { get; set; }

        public Etiqueta etiqueta { get; set; }
        public Nota nota { get; set; }
    }
}
