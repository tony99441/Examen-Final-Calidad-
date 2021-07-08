using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ExamenFinal.ConexionBD;
using ExamenFinal.Models;

namespace ExamenFinal.Repository
{
    public interface IUsuarioRepository
    {
        
        public Usuario ObtenerUsuarioLogin(Claim claim);
        public Usuario EncontrarUsuario(String user, String password);
        public void AgregarUsuario(string Username, string Password, string Nombres);

        public List<Usuario> TodosLosUsuarios();
        public Dictionary<int, String> IndicesPorId();
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private FinalContext _context;

        public UsuarioRepository(FinalContext context)
        {
            _context = context;
        }

        public Usuario EncontrarUsuario(string user, string password)
        {
            var Usuario = _context.Usuarios.Where(o => o.Username == user && o.Password == password).FirstOrDefault();
            return Usuario;
        }

        public void AgregarUsuario(string Username, string Password, string Nombres)
        {
            Usuario nuevo = new Usuario();
            nuevo.Username = Username;
            nuevo.Password = Password;
            nuevo.Nombres = Nombres;
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Usuario> TodosLosUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Dictionary<int, string> IndicesPorId()
        {
            Dictionary<int, string> indices = new Dictionary<int, string>();
            var usuarios = _context.Usuarios.ToList();

            foreach (var item in usuarios)
            {
                indices.Add(item.Id,item.Nombres);
            }

            return indices;
        }

        public Usuario ObtenerUsuarioLogin(Claim claim)
        {
            var user = _context.Usuarios.FirstOrDefault(o => o.Username == claim.Value);
            return user;
        }

   
    }
}
