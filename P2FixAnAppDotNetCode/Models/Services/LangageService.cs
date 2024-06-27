using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Fourni des méthodes de services pour gérer la langue de l'application
    /// </summary>
    public class LangageService : ILangageService
    {
        /// <summary>
        /// Positionne la langue de l'interface utilisateur
        /// </summary>
        public void ChangeLangageInterfaceUtilisateur(HttpContext context, string langage)
        {
            string culture = SetCulture(langage);
            MettreAJourLeCookieDeCulture(context, culture);
        }
        /// <summary>
        /// Positionne la culture
        /// </summary>
        public string SetCulture(string langage)
        {
            string culture = "";
            
            switch (langage)
            {
                case "English":
                    culture = "en-GB";
                    break;
                case "French":
                    culture = "fr-FR";
                    break;
                case "Spanish":
                    culture = "es-ES";
                    break;
            }
            return culture;
        }
        /// <summary>
        /// Met à jour le cookie de culture
        /// </summary>
        public void MettreAJourLeCookieDeCulture(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
