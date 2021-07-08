using System.Collections.Generic;
using ExamenFinal.Controllers;
using ExamenFinal.Models;
using ExamenFinal.Repository;
using ExamenFinal.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ExamenFinalPruebas.ControladoresPruebas
{
    public class BlogControllerPruebas
    {
        [Test]
        public void UsuarioIngresaAlIndex()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();

            userMock.Setup(o => o.ObtenerUsuarioLogin(null)).Returns(new Usuario() { });

            etiquetaMock.Setup(o => o.TodasLasEtiquetas());


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.Index("");

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        
        [Test]
        public void UsuarioIngresaAl_Index()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            notaMock.Setup(o => o.ListaFinal(""));
            notaMock.Setup(o => o.Resumen(new List<Nota>()));
            etiquetaMock.Setup(o => o.TodasLasEtiquetas());
            notaMock.Setup(o => o.detallesNotasEtiquetas());

            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog._Index("");

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        
        [Test]
        public void UsuarioCreaNotaForm()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.CrearNota();

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        [Test]
        public void UsuarioCreaNota()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            notaMock.Setup(o => o.CrearNota(nota,"matematica","Comunicacion","Jugar","Tareas"));
          

            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.CrearNotaA(nota,"matematica","Comunicacion","Jugar","Tareas");

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        [Test]
        public void UsuarioEliminaNota()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            notaMock.Setup(o => o.EliminarNota(nota.Id));


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.EliminarNotra(nota.Id);

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        [Test]
        public void UsuarioEditaNotaForm()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            notaMock.Setup(o => o.buscarNota(nota.Id));


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.EditarNota(nota.Id);

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        [Test]
        public void UsuarioEditaNota()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            notaMock.Setup(o => o.EditarNota(nota));


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.EditarNotaA(nota);

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        
        [Test]
        public void UsuarioEntraDetalleNota()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            notaMock.Setup(o => o.buscarNota(nota.Id));


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.DetalleNota(nota.Id);

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        
        [Test]
        public void UsuarioComparteNotaForm()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            userMock.Setup(o => o.TodosLosUsuarios());


            var configblog= new BlogController(null, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.Compartir(nota.Id);

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        [Test]
        public void UsuarioComparteNota()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            Usuario usuario = new Usuario();
            userMock.Setup(o => o.ObtenerUsuarioLogin(null)).Returns(new Usuario() { });
            notaMock.Setup(o => o.CompartirNota(usuario.Id,nota.Id,usuario));


            var configblog= new BlogController(cookMock.Object, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.CompartirNota(usuario.Id,nota.Id);

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        
        [Test]
        public void UsuarioVeLasNotasCompartidas()
        {
            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();
            var notaMock =new Mock<INotaRepository>();
            var etiquetaMock =new Mock<IEtiquetaRepository>();
            Nota nota = new Nota();
            Usuario usuario = new Usuario();
            userMock.Setup(o => o.ObtenerUsuarioLogin(null)).Returns(new Usuario() { });
            notaMock.Setup(o => o.MisNotas(usuario));
            notaMock.Setup(o => o.detallesNotasEtiquetas());
            notaMock.Setup(o => o.Resumen(new List<Nota>()));
            etiquetaMock.Setup(o => o.TodasLasEtiquetas());

            var configblog= new BlogController(cookMock.Object, userMock.Object, notaMock.Object, 
                etiquetaMock.Object);
            var guardarCom = configblog.NotasCompartidas();

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }

    }
}