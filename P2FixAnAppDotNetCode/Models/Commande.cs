using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2FixAnAppDotNetCode.Models
{
    public class Commande
    {
        [BindNever]
        public int IdCommande { get; set; }
        [BindNever]
        public ICollection<LignePanier>? Lignes { get; set; }
        [Required(ErrorMessage = "ErrorMissingName")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "ErrorMissingAddress")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "ErrorMissingCity")]
        public string Ville { get; set; }
        // BeFr - Ajout : Required
        [Required(ErrorMessage = "ErrorMissingZip")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "ErrorMissingCountry")]
        public string Pays { get; set; }

        [BindNever]
        public DateTime Date { get; set; }
    }
}
