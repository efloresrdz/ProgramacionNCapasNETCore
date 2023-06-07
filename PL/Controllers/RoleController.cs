using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;
using ML;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;


namespace PL.Controllers
{
	public class RoleController : Controller
	{
		private RoleManager<IdentityRole> roleManager;
		public RoleController(RoleManager<IdentityRole> roleMgr)
		{
			roleManager = roleMgr;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			ML.Role rol = new ML.Role();
			rol.Roles = new List<object>();

			var Roles = roleManager.Roles.ToList();
			return View(Roles);
		}


	


        [HttpPost]
		public async Task<IActionResult> Form([Required] Microsoft.AspNetCore.Identity.IdentityRole rol)
        {
            var role = await roleManager.FindByIdAsync(rol.Id);
            if (ModelState.IsValid)
			{
	
                if (role==null)
                {

                   
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole { Name=rol.Name,Id = rol.Id});

					if (result.Succeeded)
					{

						/*Se Inserto Correctamente el dato*/
						return RedirectToAction("GetAll");
					}
					else
					{
						/*Ocurrio Un error */
					}
				}
                else
                {

					IdentityResult result = await roleManager.UpdateAsync(rol);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAll");
                    }
                }



                //  Errors(result);
            }




            return View(rol);
		}



		[HttpGet]
        public async Task<IActionResult> Form(string ? Id)
		{
			IdentityRole role = new IdentityRole();

			if (Id == null)
			{
				return View(role);

			}
			else
			{
				 role = await roleManager.FindByIdAsync(Id);

                return View(role);
            }


		}


		

            [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAll");
                }

            }

            return View("GetAll");
        }



    }
}