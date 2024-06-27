namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProduitService
    {
        List<Produit> GetTousLesProduits();
        Produit GetProduitParId(int id);
        void MetAJourLesQuantitesDuPanier(Panier panier);
    }
}
