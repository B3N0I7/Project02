namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProduitRepository
    {
        public List<Produit> GetTousLesProduits();

        void MetAJourLaQuantiteDunProduit(int idProduit, int quantiteASupprimer);
    }
}
