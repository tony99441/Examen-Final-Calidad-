using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public string Contenido { get; set; }
        public List<DetalleNotaEtiqueta> detalleNotaEtiquetas { get; set; }
    }
}
