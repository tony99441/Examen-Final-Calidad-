using ExamenFinal.Controllers;
using ExamenFinal.Models;
using ExamenFinal.Repository;
using ExamenFinal.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ExamenFinalPruebas.ControladoresPruebas
{
    public class AuthControllerPruebas
    {
        [Test]
        public void UsuarioSeLoguea()
        {
            var usuario = new Usuario();

            usuario.Password = "admin";
            usuario.Username = "admin";


            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.EncontrarUsuario(usuario.Username, usuario.Password)).Returns(usuario);

            var cookMock = new Mock<ICookieAuthService>();

            var authCont = new AuthController(userMock.Object, cookMock.Object);
            var log = authCont.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(log);
        }


        [Test]
        public void UsuarioNoSeLoguea()
        {
            var usuario = new Usuario();

            usuario.Password = "admin1";
            usuario.Username = "admin2222";


            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.EncontrarUsuario(usuario.Username, usuario.Password)).Returns(usuario);

            var cookMock = new Mock<ICookieAuthService>();

            var authCont = new AuthController(userMock.Object, cookMock.Object);

            var log = authCont.Login("admin", "admin");

            Assert.IsInstanceOf<ViewResult>(log);
        }

    }
}
