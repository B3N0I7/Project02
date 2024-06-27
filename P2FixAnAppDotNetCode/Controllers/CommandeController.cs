using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class CommandeController : Controller
    {
        private readonly IPanier _panier;
        private readonly ICommandeService _commandeService;
        private readonly IStringLocalizer<CommandeController> _localiseur;

        public CommandeController(IPanier panier, ICommandeService service, IStringLocalizer<CommandeController> localiseur)
        {
            _panier = panier;
            _commandeService = service;
            _localiseur = localiseur;
        }

        public ViewResult Index() => View(new Commande());

        [HttpPost]
        public IActionResult Index(Commande commande)
        {
            if (!((Panier) _panier).Lignes.Any())
            {
                ModelState.AddModelError("", _localiseur["CartEmpty"]);
            }
            if (ModelState.IsValid)
            {
                commande.Lignes = (_panier as Panier)?.Lignes.ToArray();
                _commandeService.EnregistreLaCommande(commande);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(commande);
            }
        }

        public ViewResult Completed()
        {
            _panier.Vider();
            return View();
        }
    }
}
