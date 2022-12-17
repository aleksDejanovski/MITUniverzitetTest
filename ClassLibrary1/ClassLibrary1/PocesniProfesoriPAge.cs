using OpenQA.Selenium;

namespace ClassLibrary1
{
    internal class PocesniProfesoriPAge
    {
        private IWebDriver driver;

        public PocesniProfesoriPAge(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement PocesenProfesor => driver.FindElement(By.XPath("//h3[contains(text(),'Академик др. Жан Митрев')]"));
    }
}