using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// La classe qui gère les données des commandes
    /// </summary>
    public class CommandeRepository : ICommandeRepository
    {
        private readonly List<Commande> _commandes;

        public CommandeRepository()
        {
            _commandes = new List<Commande>();
        }

        /// <summary>
        /// Enregistre une commande
        /// </summary>
        public void Enregistrer(Commande commande)
        {
            _commandes.Add(commande);
        }
    }
}