using System;
using OpenQA.Selenium;

namespace ClassLibrary1
{
    internal class BezbednostniNaukiPage
    {
        private IWebDriver driver;

        public BezbednostniNaukiPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement vtorCiklusTab => driver.FindElement(By.CssSelector("a[role='tab'][href='#tab_post']"));

        public IWebElement kriminologijaTab => driver.FindElement(By.XPath("//a[contains(text(),'втор циклус студии')]"));

        public IWebElement dokazDekaKriminologijaEKliknata => driver.FindElement(By.XPath("//a[contains(text(),'втор циклус студии')]"));

        public IWebElement elementBeznednost => driver.FindElement(By.CssSelector("a[href='#panel_2']"));

        public IWebElement dokazDekaEKlinataBezbednost => driver.FindElement(By.CssSelector("a[href='#faculty-based_2_0']"));
        internal void clickVtorCiklus()
        {
            vtorCiklusTab.Click();
        }

        internal void clickKriminologijaTab()
        {
            kriminologijaTab.Click();
        }

        internal void clickBezbednost()
        {
            elementBeznednost.Click();
        }
    }
}