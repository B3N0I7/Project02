using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;

namespace P2FixAnAppDotNetCode.Components
{
    public class ResumePanierViewComponent : ViewComponent
    {
        private readonly Panier _panier;

        public ResumePanierViewComponent(IPanier panier)
        {
            _panier = panier as Panier;
        }

        public IViewComponentResult Invoke()
        {
            return View(_panier);
        }
    }
}
