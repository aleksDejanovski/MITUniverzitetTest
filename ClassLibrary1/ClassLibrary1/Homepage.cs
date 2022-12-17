using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ClassLibrary1
{
    internal class Homepage
    {
        public IWebDriver driver { get; }
        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement zaNasKopce => driver.FindElement(By.XPath("//a[contains(text(),'За Нас')]"));

        public IWebElement istorijaKopce => driver.FindElement(By.CssSelector("a[href='/istorijat']"));

        public IWebElement IstorijaTitle => driver.FindElement(By.XPath("//h1[@class='page-title']"));

        public IWebElement zaUniverzitetot => driver.FindElement(By.CssSelector("a[href='/za-univerzitetot']"));

        public IWebElement zaUniverzitetotTitle => driver.FindElement(By.ClassName("page-title"));

        public IWebElement novostiElement => driver.FindElement(By.XPath("//a[contains(text(),'Новости')]"));

        public IWebElement nastaniElement => driver.FindElement(By.LinkText("Настани"));

        public IWebElement NastaniNaslov => driver.FindElement(By.XPath("//h1[@class='page-title']"));

        public IWebElement fakultetiTab => driver.FindElement(By.XPath("//a[contains(text(),'Факултети')]"));

        public IWebElement beznednostniNauki => driver.FindElement(By.CssSelector("a[href='/fakulteti/fakultet-za-bezbednosni-nauki']"));

        public IWebElement titleBezbednostni => driver.FindElement(By.ClassName("page-title"));

        // element za ekonomski fakultet
        public IWebElement ekonomskifaksTab => driver.FindElement(By.XPath("//a[contains(text(),'Економски факултет')]"));

        // element za vraboteni
        public IWebElement vraboteni => driver.FindElement(By.XPath("//a[contains(text(),'Вработени')]"));

        //element za pocesni profesori
        public IWebElement pocesniProfesori => driver.FindElement(By.CssSelector("a[href='/pocesni-profesori']"));

        internal void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.mit.edu.mk/");
        }

        internal void ClickIstorijaTab()
        {
            zaNasKopce.Click();
        }

        internal void ClickIstorijaTabOtvoren()
        {
            istorijaKopce.Click();
        }

        internal void ZaUniverzitetotClick()
        {
            zaUniverzitetot.Click();
        }

        internal void ClickNovositiTab()
        {
            novostiElement.Click();
        }

        internal void clickNastaniElement()
        {
            nastaniElement.Click();
        }


        internal BezbednostniNaukiPage openBezbednostniNaukiTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            fakultetiTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(beznednostniNauki)).Click();
            return new BezbednostniNaukiPage(driver);
        }

        internal EkonomskiFakultetPage clickEkonomskiFakultet()
        {
            ekonomskifaksTab.Click();
            return new EkonomskiFakultetPage(driver);
        }

        internal PocesniProfesoriPAge OpenPocesni()
        {
            vraboteni.Click();
            pocesniProfesori.Click();
            return new PocesniProfesoriPAge(driver);
        }
    }
}