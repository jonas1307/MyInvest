using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyInvest.Domain.Interfaces.Services;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Configuration;
using MyInvest.Infrastructure.Crosscutting.AspNetIdentity.Model;

namespace MyInvest.Presentation.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ApplicationUserManager _userManager;

        public UsuarioController(IUsuarioService usuarioService, ApplicationUserManager userManager)
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var model = _usuarioService.GetAll();

            return View(model);
        }

        //TODO: Implement editing
        //public ActionResult Edit(string id)
        //{
        //    var model = _usuarioService.GetById(id);

        //    return View(model);
        //}

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Usuario");

                AddErrors(result);
            }

            return View("Novo", model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}