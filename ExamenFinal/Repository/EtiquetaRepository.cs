using System.Collections.Generic;
using System.Linq;
using ExamenFinal.ConexionBD;
using ExamenFinal.Models;

namespace ExamenFinal.Repository
{

public interface IEtiquetaRepository
{
    public List<Etiqueta> TodasLasEtiquetas();
}

public class EtiquetaRepository : IEtiquetaRepository
{
    private FinalContext _context;

    public EtiquetaRepository(FinalContext context)
    {
        _context = context;
    }

    public List<Etiqueta> TodasLasEtiquetas()
    {
       return _context.etiquetas.ToList();
    }
}
}