using Xunit;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCodeTest
{
    public class LangageTest
    {
        [Fact]
        public void TesteLangage()
        {
            //Arrange
            ILangageService langageService = new LangageService();
            string langage = "Spanish";

            //Act
            string culture = langageService.SetCulture(langage);

            //Assert
            Assert.Same("es-ES", culture);
        }
    }
}
