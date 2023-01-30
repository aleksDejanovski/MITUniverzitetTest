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
        public IWebDriver driver;
        public IWebDriver wait;
        internal Homepage page;
        internal BezbednostniNaukiPage pageBez;
        internal EkonomskiFakultetPage pageEko;
        internal PocesniProfesoriPAge pagePocesni;

        [SetUp]
        public void Setiranje()
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
        public void Teardownmethod()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void IstorijatTestiranje()
        {

            page.GoTo();
            page.ClickIstorijaTab();
            page.ClickIstorijaTabOtvoren();
            Assert.AreEqual("Историјат", page.IstorijaTitle.Text, "Ne e otvorena stranicata za istorijat");
        }
        [Test]
        public void ZaUniverzitetot()
        {
            page.GoTo();
            page.ClickIstorijaTab();
            page.ZaUniverzitetotClick();
            Assert.AreEqual("За универзитетот", page.zaUniverzitetotTitle.Text);

        }
        [Test]
        public void NovostiNastani()
        {
            page.GoTo();
            page.ClickNovositiTab();
            page.clickNastaniElement();
            page.NastaniNaslov.Text.Contains("Настани");
        }
        [Test]
        public void BezbednostniNaukiDaliSeOtvara()
        {
            page.GoTo();
            page.openBezbednostniNaukiTab();
            page.titleBezbednostni.Text.Contains("безбедносни ");
        }

        [Test]
        public void BezbednostniNaukiVtorSemestar()
        {
            page.GoTo();
            page.openBezbednostniNaukiTab();
            pageBez.clickVtorCiklus();
            pageBez.clickKriminologijaTab();
            Assert.AreEqual("ВТОР ЦИКЛУС СТУДИИ", pageBez.dokazDekaKriminologijaEKliknata.Text, "ne e otvoren tabot za kriminologija");

        }
        [Test]
        public void TestDaliMozeBezbednostNasokaDaSeOdbere()
        {
            page.GoTo();
            page.openBezbednostniNaukiTab();
            pageBez.clickBezbednost();
            Assert.IsTrue(pageBez.dokazDekaEKlinataBezbednost.Enabled);

        }
        [Test]
        public void EkonomskiFakultet()
        {
            page.GoTo();
            page.fakultetiTab.Click();
            page.clickEkonomskiFakultet();
            Assert.AreEqual("Економски фалултет", pageEko.ekonomskiTitle.Text);
        }

        [Test]
        public void PocesniProfesoriTest()
        {
            page.GoTo();
            page.OpenPocesni();
            Assert.AreEqual("Академик др. Жан Митрев", pagePocesni.PocesenProfesor.Text);
        }
        [Test]
        public void FacebookFuncionality()
        {
            page.GoTo();
            page.FacebookClick();
            page.SwitchToLastTab();
            Assert.IsTrue(driver.Url.Contains("https://www.facebook.com/mituniverzitetskopje"));

        }
        [Test]
        public void TweeterFunck()
        {
            page.GoTo();
            page.TweeterClick();
            page.SwitchToLastTab();
            Assert.IsTrue(driver.Url.Contains("https://twitter.com/"));

        }
        [Test]
        public void YouTubeFunck()
        {
            page.GoTo();
            page.YouTubeClick();
            page.SwitchToLastTab();
            Assert.IsTrue(driver.Url.Contains("https://www.youtube.com/"));

        }
        [Test]
        public void LanguageFunck()
        {
            page.GoTo();
            page.EnglishClick();
            Assert.AreEqual("Home", page.HomeElement.Text);

        }
        [Test]
        public void TehniuckaOpremenostTest()
        {
            page.GoTo();
            page.TehnickaOpremenost();
            Assert.IsTrue(driver.Url.Contains("https://www.mit.edu.mk/tehnicka-opremenost"));
        }
    }
}