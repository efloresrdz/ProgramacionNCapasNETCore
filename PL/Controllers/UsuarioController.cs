
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private UserManager<IdentityUser> userManager;
        public UsuarioController(UserManager<IdentityUser> usersMgr)
        {
            userManager = usersMgr;
        }



        public IActionResult GetAll()
        {

            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            var users = userManager.Users.ToList();
 
            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> Form([Required] Microsoft.AspNetCore.Identity.IdentityUser user)
        {
            var result1 = await userManager.AddToRoleAsync(user, "Admin");
            return View();
        }



    }
}