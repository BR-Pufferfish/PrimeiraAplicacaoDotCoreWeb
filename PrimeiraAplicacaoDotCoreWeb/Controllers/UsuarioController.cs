using Microsoft.AspNetCore.Mvc;
using PrimeiraAplicacaoDotCoreWeb.Models.Usuario;
using Servico;

namespace PrimeiraAplicacaoDotCoreWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {

            var db = new Db();
            
            var listaUsuarioDTO = db.GetUsuario();
            var listaDeUsuarios = new List<Usuario>();

            foreach (var usuarioDTO in listaUsuarioDTO)
            {
                var usuario = new Usuario();
                usuario.Id = usuarioDTO.id;
                usuario.Nome = usuarioDTO.nome;
                usuario.Sobrenome = usuarioDTO.sobrenome;
                usuario.Email = usuarioDTO.email;
                listaDeUsuarios.Add(usuario); 

            }


            return View(listaDeUsuarios);
        }

        public IActionResult NovoUsuario()
        {
            return View();
        }

        public IActionResult PersistirUsuario(string nome, string sobrenome, string email)
        {
            return RedirectToAction("Index");
        }
    }
}
