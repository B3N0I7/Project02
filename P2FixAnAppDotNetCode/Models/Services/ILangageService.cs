using Microsoft.AspNetCore.Http;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface ILangageService
    {
        void ChangeLangageInterfaceUtilisateur(HttpContext context, string langage);
        string SetCulture(string langage);
        void MettreAJourLeCookieDeCulture(HttpContext context, string culture);
    }
}
