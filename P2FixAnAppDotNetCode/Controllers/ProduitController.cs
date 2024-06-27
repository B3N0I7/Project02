using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;
        private readonly ILangageService _langageService;
        public ProduitController(IProduitService produitService, ILangageService langageService)
        {
            _produitService = produitService;
            _langageService = langageService;
        }
        public IActionResult Index()
        {
            List< Produit > produits = _produitService.GetTousLesProduits();
            return View(produits);
        }
    }
}