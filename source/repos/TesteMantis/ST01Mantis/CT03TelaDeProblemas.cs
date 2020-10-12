using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ST01Mantis
{
    [TestFixture]
    public class CT03TelaDeProblemas
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://mantis-prova.base2.com.br/";
            verificationErrors = new StringBuilder();
        }
        
        
        
        [Test]
        public void TheCT03TelaDeProblemasTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("9087");
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("leandro.matias");
            driver.FindElement(By.CssSelector("input.button")).Click();

            driver.Navigate().GoToUrl(baseURL + "/my_view_page.php");
            new SelectElement(driver.FindElement(By.Name("project_id"))).SelectByText("Leandro Matias´s Project");

            driver.FindElement(By.LinkText("View Issues")).Click();
            // Verificando elementos
            Assert.IsTrue(IsElementPresent(By.LinkText("ID")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Category")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Severity")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Status")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Updated")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Summary")));

            // Verificando criação de ID do problema
            Assert.IsTrue(IsElementPresent(By.CssSelector("#buglist > tbody > tr:nth-child(5) > td:nth-child(4) > a")));
            // Acessando problema pelo numero do ID
            driver.FindElement(By.CssSelector("#buglist > tbody > tr:nth-child(5) > td:nth-child(4) > a")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
