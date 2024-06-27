using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class PanierController : Controller
    {
        private readonly IPanier _panier;
        private readonly IProduitService _produitService;

        public PanierController(IPanier pPanier, IProduitService produitService)
        {
            _panier = pPanier;
            _produitService = produitService;
        }

        public ViewResult Index()
        {
            return View(_panier as Panier);
        }

        [HttpPost]
        public RedirectToActionResult AjoutPanier(int id)
        {
            Produit produit = _produitService.GetProduitParId(id);

            if (produit != null)
            {
                _panier.AjouterElement(produit, 1);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Produit");
            }
        }

        public RedirectToActionResult SuppressionDansPanier(int id)
        {
            Produit produit = _produitService.GetTousLesProduits().FirstOrDefault(p => p.Id == id);

            if (produit != null)
            {
                _panier.SupprimerLigne(produit);
            }
            return RedirectToAction("Index");
        }
    }
}
