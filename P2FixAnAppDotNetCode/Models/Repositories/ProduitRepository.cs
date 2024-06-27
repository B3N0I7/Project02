namespace P2FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// La classe qui gère les données des produits
    /// </summary>
    public class ProduitRepository : IProduitRepository
    {
        private static List<Produit> _produits = new List<Produit>();
        public ProduitRepository()
        {
            if (_produits.Count == 0)
            {
                 GenereDesProduits();
            }
        }
        /// <summary>
        /// Génère une liste de produits par défaut
        /// </summary>
        private void GenereDesProduits()
        {
            int id = 0;
            _produits.Add(new Produit(++id, 10, 92.50, "Echo Dot", "(2nde Génération) - Noir"));
            _produits.Add(new Produit(++id, 20, 9.99, "Câble Anker 90cm en nylon tressé", "Câble micro USB anti-noeud"));
            _produits.Add(new Produit(++id, 30, 69.99, "Écouteurs JVC HAFX8R", "Riptidz, Intra-auriculaire"));
            _produits.Add(new Produit(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Téléphone sans fil"));
            _produits.Add(new Produit(++id, 50, 895.00, "NOKIA OEM BL-5J", "Téléphone portable"));
        }
        /// <summary>
        /// Récupère tous les produits depuis l'inventaire
        /// </summary>
        public List<Produit> GetTousLesProduits()
        {
            List<Produit> liste = _produits.Where(p => p.Stock > 0).OrderBy(p => p.Nom).ToList();
            return liste;
        }
        /// <summary>
        /// Met à jour le stock d'un produit dans l'inventaire à partir de son id
        /// </summary>
        public void MetAJourLaQuantiteDunProduit(int idProduit, int quantiteASupprimer)
        {
            Produit produit = _produits.First(p => p.Id == idProduit);
            produit.Stock = produit.Stock - quantiteASupprimer;

            if (produit.Stock == 0)
                _produits.Remove(produit);
        }
    }
}
