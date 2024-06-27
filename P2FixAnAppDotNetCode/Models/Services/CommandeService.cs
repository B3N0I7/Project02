using System;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Fournit les services pour gérer une commande
    /// </summary>
    public class CommandeService : ICommandeService
    {
       private readonly IPanier _panier;
       private readonly ICommandeRepository _repository;
       private readonly IProduitService _produitService;

        public CommandeService(IPanier panier, ICommandeRepository commandeRepository, IProduitService produitService)
        {
            _repository = commandeRepository;
            _panier = panier;
            _produitService = produitService;
        }

        /// <summary>
        /// Enregistre une commande
        /// </summary>
        public void EnregistreLaCommande(Commande commande)
        {
            commande.Date = DateTime.Now;
            _repository.Enregistrer(commande);
            MetAJourInventaire();
        }

        /// <summary>
        /// Met à jour les quantités de produit dans l'inventaire et vide le panier
        /// </summary>
        private void MetAJourInventaire()
        {
            _produitService.MetAJourLesQuantitesDuPanier(_panier as Panier);
            _panier.Vider();
        }
    }
}
