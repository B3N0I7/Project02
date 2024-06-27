using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Components
{
    public class SelectionLangageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ILangageService langageService)
        {
            return View(langageService);
        }
    }
}
