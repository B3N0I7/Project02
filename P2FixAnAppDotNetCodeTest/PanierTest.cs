using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCodeTest
{
    public class PanierTest
    {
        [Fact]
        public void AjoutProduitPanierTest()
        {
            //Arrange
            Panier panier = new Panier();
            Produit produit1 = new Produit(1, 0, 10, "nomProduit", "description");
            //Produit produit2 = new Produit(1, 0, 10, "nomProduit", "description");

            //Act
            panier.AjouterElement(produit1, 1);
            //panier.AjouterElement(produit2, 1);

            //Assert
            Assert.NotEmpty(panier.Lignes);
            Assert.Single(panier.Lignes);
            //Assert.Equal(2, panier.Lignes.First().Quantite);
        }
        [Fact]
            public void MoyennePanierTest()
        {
            //Arrange
            IPanier panier = new Panier();
            IProduitRepository produitRepository = new ProduitRepository();
            ICommandeRepository commandeRepository = new CommandeRepository();
            IProduitService produitService = new ProduitService(produitRepository, commandeRepository);

            //Act
            IEnumerable<Produit> produits = produitService.GetTousLesProduits();
            panier.AjouterElement(produits.First(p => p.Id == 1), 1);
            panier.AjouterElement(produits.First(p => p.Id == 2), 1);
            panier.AjouterElement(produits.First(p => p.Id == 3), 1);
            double valeurMoyenne = panier.GetValeurMoyenne();
            double valeurAttendue = (92.5 + 9.99 + 69.99) / 3;

            //Assert
            Assert.Equal(valeurMoyenne, valeurAttendue);
        }
        [Fact]
        public void SommePanierTest()
        {
            //Arrange
            IPanier panier = new Panier();
            IProduitRepository produitRepository = new ProduitRepository();
            ICommandeRepository commandeRepository = new CommandeRepository();
            IProduitService produitService = new ProduitService(produitRepository, commandeRepository);

            //Act
            IEnumerable<Produit> produits = produitService.GetTousLesProduits();
            panier.AjouterElement(produits.First(p => p.Id == 1), 1);
            panier.AjouterElement(produits.First(p => p.Id == 2), 1);
            panier.AjouterElement(produits.First(p => p.Id == 3), 1);
            double valeurTotale = panier.GetValeurTotale();
            double valeurAttendue = (92.5 + 9.99 + 69.99);

            //Assert
            Assert.Equal(valeurAttendue, valeurTotale);
        }
        [Fact]
        public void TrouveProduitPanier()
        {
            //Arrange
            Panier panier = new Panier();
            Produit produit1 = new Produit(100, 25, 50, "nomProduit", "descriptifProduit");

            //Act
            panier.AjouterElement(produit1, 1);
            Produit resultat = panier.TrouveProduitDansLesLignesDuPanier(100);

            //Assert
            Assert.NotNull(resultat);
        }
    }
}