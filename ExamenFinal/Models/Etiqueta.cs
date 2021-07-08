using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Etiqueta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<DetalleNotaEtiqueta> detalleNotaEtiquetas { get; set; }
    }
}
