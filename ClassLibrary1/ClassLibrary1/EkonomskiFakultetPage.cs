using OpenQA.Selenium;

namespace ClassLibrary1
{
    internal class EkonomskiFakultetPage
    {
        private IWebDriver driver;

        public EkonomskiFakultetPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement ekonomskiTitle => driver.FindElement(By.ClassName("page-title"));
    }
}