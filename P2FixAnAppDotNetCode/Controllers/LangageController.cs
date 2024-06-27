using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class LangageController : Controller
    {
        private readonly ILangageService _langageService;

        public LangageController(ILangageService langageService)
        {
            _langageService = langageService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangerLangueInterfaceUtilisateur(LangageViewModel model, string returnUrl)
        {
            if (model.Langage != null)
            {
                _langageService.ChangeLangageInterfaceUtilisateur(HttpContext, model.Langage);
            }

            return Redirect(returnUrl);
        }
    }
}
