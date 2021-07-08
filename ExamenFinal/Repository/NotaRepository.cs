using System;
using System.Collections.Generic;
using System.Linq;
using ExamenFinal.ConexionBD;
using ExamenFinal.Models;

namespace ExamenFinal.Repository
{
    public interface INotaRepository
    {
        public List<Nota> TodasLasNotas();
        public Dictionary<int, string> Resumen(List<Nota> listaFinal);
        public List<DetalleNotaEtiqueta> detallesNotasEtiquetas();
        public List<Nota> ListaFinal(string busqueda);
        public void CrearNota(Nota nota, string Matematica, string Comunicacion, string Jugar, string Tareas);

        public void EliminarNota(int IdNota);

        public Nota buscarNota(int IdNota);

        public void EditarNota(Nota nota);

        public void CompartirNota(int IdUsuario, int IdNota, Usuario user);

        public List<Nota> MisNotas(Usuario user);
    }

    public class NotaRepository : INotaRepository
    {
        private FinalContext _context;

        public NotaRepository(FinalContext context)
        {
            _context = context;
        }

        public List<Nota> TodasLasNotas()
        {
            return _context.notas.ToList();
        }

        public Dictionary<int, string> Resumen(List<Nota> listaFinal)
        {
            Dictionary<int, string> resumen = new Dictionary<int, string>();
            var contenido = "";
            foreach (var item in listaFinal)
            {
                if (item.Contenido.Length < 50)
                {
                    contenido = item.Contenido;
                }
                else
                {
                    contenido = item.Contenido.Substring(0, 50);
                }

                resumen.Add(item.Id, contenido);
            }

            return resumen;
        }

        public List<DetalleNotaEtiqueta> detallesNotasEtiquetas()
        {
            return _context.DetalleNotaEtiquetas.ToList();
        }

        public List<Nota> ListaFinal(string busqueda)
        {
            var notas = TodasLasNotas();
            var etiquetasBuscadas = new List<Etiqueta>();
            var etiquetas = _context.etiquetas.ToList();
            var ListadetallesNotasEtiquetas= detallesNotasEtiquetas();
            if (!string.IsNullOrEmpty(busqueda))
            {
                notas = _context.notas.Where(o => o.Titulo.ToLower().Contains(busqueda) || o.Contenido.ToLower().Contains(busqueda)).ToList();
                etiquetasBuscadas = _context.etiquetas.Where(o => o.Nombre.ToLower().Contains(busqueda)).ToList();
            }

            var indicesEtiquetas = etiquetasBuscadas.Select(o => o.Id).ToList();
            List<DetalleNotaEtiqueta> nuevaIndices = new List<DetalleNotaEtiqueta>();
            foreach (var item in ListadetallesNotasEtiquetas)
            {
                if (indicesEtiquetas.Contains(item.IdEtiqueta))
                {
                    nuevaIndices.Add(item);
                }
            }

            var TNotas = _context.notas.ToList();
            List<Nota> nueva = new List<Nota>();
            var indiceDetalles = nuevaIndices.Select(o => o.IdNota).ToList();
            foreach (var item in TNotas)
            {
                if (indiceDetalles.Contains(item.Id))
                {
                    nueva.Add(item);
                }
            }

            var listaFinal = nueva.Union(notas).ToList();
            return listaFinal;
        }

        public void CrearNota(Nota nota, string Matematica, string Comunicacion, string Jugar, string Tareas)
        {
           

            nota.UltimaModificacion = DateTime.Now;
            _context.notas.Add(nota);
            
            _context.SaveChanges();
            var buscarnota = _context.notas.FirstOrDefault(o => o.Titulo == nota.Titulo && o.Contenido == nota.Contenido);
            if (Matematica!= null)
            {
                DetalleNotaEtiqueta nuevo = new DetalleNotaEtiqueta();
                nuevo.IdNota = buscarnota.Id;
                nuevo.etiqueta = _context.etiquetas.Where(o => o.Nombre == Matematica).FirstOrDefault();
                _context.DetalleNotaEtiquetas.Add(nuevo);
                _context.SaveChanges();
            }
            if (Comunicacion!= null)
            {
                DetalleNotaEtiqueta nuevo = new DetalleNotaEtiqueta();
                nuevo.IdNota = buscarnota.Id;
                nuevo.etiqueta = _context.etiquetas.Where(o => o.Nombre == Comunicacion).FirstOrDefault();
                _context.DetalleNotaEtiquetas.Add(nuevo);
                _context.SaveChanges();
            }
            if (Jugar!= null)
            {
                DetalleNotaEtiqueta nuevo = new DetalleNotaEtiqueta();
                nuevo.IdNota = buscarnota.Id;
                nuevo.etiqueta = _context.etiquetas.Where(o => o.Nombre == Jugar).FirstOrDefault();
                _context.DetalleNotaEtiquetas.Add(nuevo);
                _context.SaveChanges();
            }
            if (Tareas!= null)
            {
                DetalleNotaEtiqueta nuevo = new DetalleNotaEtiqueta();
                nuevo.IdNota = buscarnota.Id;
                nuevo.etiqueta = _context.etiquetas.Where(o => o.Nombre == Tareas).FirstOrDefault();
                _context.DetalleNotaEtiquetas.Add(nuevo);
                _context.SaveChanges();
            }
        }

        public void EliminarNota(int IdNota)
        {
            var nota = _context.notas.Where(o => o.Id == IdNota).FirstOrDefault();
            _context.notas.Remove(nota);
            _context.SaveChanges();
        }

        public Nota buscarNota(int IdNota)
        {
           return _context.notas.Where(o => o.Id == IdNota).FirstOrDefault();
        }

        public void EditarNota(Nota nota)
        {
            var nota2 = _context.notas.Where(o => o.Id == nota.Id).FirstOrDefault();
            nota2.Contenido = nota.Contenido;
            nota2.Titulo = nota.Titulo;
            nota2.UltimaModificacion = DateTime.Now;
            _context.SaveChanges();
        }

        public void CompartirNota(int IdUsuario, int IdNota, Usuario user)
        {
            NotaCompartida nueva = new NotaCompartida();
            nueva.IdNota = IdNota;
            nueva.IdUsuario1 = user.Id;
            nueva.IdUsuario2 = IdUsuario;
            
            var notasCompartidas = _context.NotaCompartidas.ToList();

            foreach (var item in notasCompartidas)
            {
                if (item.IdNota==IdNota && item.IdUsuario1== user.Id && item.IdUsuario2== IdUsuario)
                {
                    break;
                }
            }
            _context.NotaCompartidas.Add(nueva);
            _context.SaveChanges();
        }

        public List<Nota> MisNotas(Usuario user)
        {
            var notas = _context.notas.ToList();
            var NotaQueComparti = _context.NotaCompartidas.Where(o => o.IdUsuario1 == user.Id).ToList().Select(o=>o.IdNota).ToList();
            List<Nota> MisNotas = new List<Nota>();
            foreach (var item in notas)
            {
                if (NotaQueComparti.Contains(item.Id))
                {
                    MisNotas.Add(item);
                }
            }

            return MisNotas;
        }
    }
}