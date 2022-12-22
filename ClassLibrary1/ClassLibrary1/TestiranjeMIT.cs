using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary1
{
    [TestFixture]
    public class TestiranjeMIT
    {
        IWebDriver driver;
        IWebDriver wait;
        Homepage page;
        BezbednostniNaukiPage pageBez;
        EkonomskiFakultetPage pageEko;
        PocesniProfesoriPAge pagePocesni;

        [SetUp]
        public void setiranje()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            page = new Homepage(driver);
            pageBez = new BezbednostniNaukiPage(driver);
            pageEko = new EkonomskiFakultetPage(driver);
            pagePocesni = new PocesniProfesoriPAge(driver);




        }
        [TearDown]
        public void teardownmethod()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void istorijatTestiranje()
        {

            page.GoTo();
            page.ClickIstorijaTab();
            page.ClickIstorijaTabOtvoren();
            Assert.AreEqual("Историјат", page.IstorijaTitle.Text, "Ne e otvorena stranicata za istorijat");
        }
        [Test]
        public void zaUniverzitetot()
        {
            page.GoTo();
            page.ClickIstorijaTab();
            page.ZaUniverzitetotClick();
            Assert.AreEqual("За универзитетот", page.zaUniverzitetotTitle.Text);

        }
        [Test]
        public void novostiNastani()
        {
            page.GoTo();
            page.ClickNovositiTab();
            page.clickNastaniElement();
            page.NastaniNaslov.Text.Contains("Настани");
        }
        [Test]
        public void bezbednostniNaukiDaliSeOtvara()
        {
            page.GoTo();
            page.openBezbednostniNaukiTab();
            page.titleBezbednostni.Text.Contains("безбедносни ");
        }

        [Test]
        public void bezbednostniNaukiVtorSemestar()
        {
            page.GoTo();
            page.openBezbednostniNaukiTab();
            pageBez.clickVtorCiklus();
            pageBez.clickKriminologijaTab();
            Assert.AreEqual("ВТОР ЦИКЛУС СТУДИИ", pageBez.dokazDekaKriminologijaEKliknata.Text, "ne e otvoren tabot za kriminologija");

        }
        [Test]
        public void testDaliMozeBezbednostNasokaDaSeOdbere()
        {
            page.GoTo();
            page.openBezbednostniNaukiTab();
            pageBez.clickBezbednost();
            Assert.IsTrue(pageBez.dokazDekaEKlinataBezbednost.Enabled);

        }
        [Test]
        public void ekonomskiFakultet()
        {
            page.GoTo();
            page.fakultetiTab.Click();
            page.clickEkonomskiFakultet();
            Assert.AreEqual("Економски фалултет", pageEko.ekonomskiTitle.Text);
        }

        [Test]
        public void pocesniProfesoriTest()
        {
            page.GoTo();
            page.OpenPocesni();
            Assert.AreEqual("Академик др. Жан Митрев", pagePocesni.PocesenProfesor.Text);
        }
    }
}
