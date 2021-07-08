using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenFinal.ConexionBD;
using ExamenFinal.Models;
using ExamenFinal.Repository;
using ExamenFinal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{

    [Authorize]
  public class BlogController : Controller
    {
       
        
        private readonly ICookieAuthService _cookieAuthService;
        private readonly IUsuarioRepository _usuario;
        private readonly INotaRepository _nota;
        private readonly IEtiquetaRepository _etiqueta;
        
        public BlogController(ICookieAuthService _cookieAuthService,
            IUsuarioRepository _usuario,INotaRepository _nota,IEtiquetaRepository _etiqueta) {
            this._cookieAuthService = _cookieAuthService; 
            this._usuario = _usuario; 
            this._nota = _nota; 
            this._etiqueta = _etiqueta; 
        }

        public IActionResult Index(string busqueda)
        {

            ViewBag.busqueda = busqueda;
            ViewBag.etiquetas = _etiqueta.TodasLasEtiquetas();
            return View();
        }
        public IActionResult _Index(string busqueda = "")
        {
            var listaFinal = _nota.ListaFinal(busqueda);
            ViewBag.resumen = _nota.Resumen(listaFinal);
            ViewBag.etiquetas = _etiqueta.TodasLasEtiquetas();
            ViewBag.detalles = _nota.detallesNotasEtiquetas();
            return View(listaFinal);

        }

        public IActionResult CrearNota()
        {
           
            return View();
        }
        public IActionResult CrearNotaA(Nota nota,string Matematica,string Comunicacion,string Jugar,string Tareas)
        {
          
            _nota.CrearNota(nota,Matematica,Comunicacion,Jugar,Tareas);
     
            return RedirectToAction("Index");
        }

        public IActionResult EliminarNotra(int IdNota)
        {
           _nota.EliminarNota(IdNota);
            return RedirectToAction("Index");
        }
        public IActionResult EditarNota(int IdNota)
        {
            ViewBag.Nota = _nota.buscarNota(IdNota);
            return View();
        }
        public IActionResult EditarNotaA(Nota nota)
        {
            _nota.EditarNota(nota);

            return RedirectToAction("Index");
        }
        public IActionResult DetalleNota(int IdNota)
        {
          
            ViewBag.Nota = _nota.buscarNota(IdNota);
            return View();
        }
        public IActionResult Compartir(int IdNota)
        {
            ViewBag.Usuarios = _usuario.TodosLosUsuarios();
            ViewBag.IdNota = IdNota;
            return View();
        }
        public IActionResult CompartirNota(int IdUsuario,int IdNota)
        {
            Usuario user = LoggedUser();
           _nota.CompartirNota(IdUsuario,IdNota,user);
            return RedirectToAction("Index");
        }
        
        public IActionResult NotasCompartidas()
        {
            Usuario user = LoggedUser();
        

            var MisNotas = _nota.MisNotas(user);


            var DetalleNotasEtiquetas = _nota.detallesNotasEtiquetas();

            ViewBag.detalles = DetalleNotasEtiquetas;
            ViewBag.Notas = MisNotas;
            ViewBag.resumen = _nota.Resumen(MisNotas);
            ViewBag.etiquetas = _etiqueta.TodasLasEtiquetas();
            return View();
        }
        private Usuario LoggedUser()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var claim = _cookieAuthService.ObtenerClaim();
            var user = _usuario.ObtenerUsuarioLogin(claim);
            return user;
        }
        
       
    }
}