
namespace P2FixAnAppDotNetCode.Models
{
    public interface IPanier
    {
        void AjouterElement(Produit produit, int quantite);

        void SupprimerLigne(Produit produit);

        void Vider();

        double GetValeurTotale();

        double GetValeurMoyenne();
    }
}