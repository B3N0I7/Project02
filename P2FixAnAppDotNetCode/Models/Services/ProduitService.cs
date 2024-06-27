using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Cette classe fourni les services pour gérer les produits
    /// </summary>
    public class ProduitService : IProduitService
    {
        private readonly IProduitRepository _produitRepository;
        private readonly ICommandeRepository _commandeRepository;
        public ProduitService(IProduitRepository produitRepository, ICommandeRepository commandeRepository)
        {
            _produitRepository = produitRepository;
            _commandeRepository = commandeRepository;
        }
        /// <summary>
        /// Récupère tous les produits depuis l'inventaire
        /// </summary>
        public List<Produit> GetTousLesProduits()
        {
            return _produitRepository.GetTousLesProduits();
        }
        /// <summary>
        /// Récupère un produit depuis l'inventaire à partir de son id
        /// </summary>
        public Produit GetProduitParId(int id)
        {
            var produitListe = _produitRepository.GetTousLesProduits();
            return produitListe.FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// Met à jour les quantités restantes pour chaque produit dans l'inventaire en fonction des quantités commandées
        /// </summary>
        public void MetAJourLesQuantitesDuPanier(Panier panier)
        {
            foreach (LignePanier ligne in panier.Lignes)
            {
                _produitRepository.MetAJourLaQuantiteDunProduit(ligne.Produit.Id, ligne.Quantite);
            }
        }
    }
}
