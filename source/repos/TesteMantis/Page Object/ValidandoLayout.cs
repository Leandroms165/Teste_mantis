using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TesteMantis.Page_Object
{
    class ValidandoLayout
    {
        // Verificando presença de elementos

        [FindsBy(How = How.LinkText, Using = "My View")]
        public  IWebElement MyView { get; set; }

        [FindsBy(How = How.LinkText, Using = "View Issues")]
        public IWebElement ViewIssues { get; set; }

        [FindsBy(How = How.LinkText, Using = "Report Issue")]
        public IWebElement ReportIssue { get; set; }

        [FindsBy(How = How.LinkText, Using = "Change Log")]
        public IWebElement ChangeLog { get; set; }

        [FindsBy(How = How.LinkText, Using = "Roadmap")]
        public IWebElement Roadmap { get; set; }

        [FindsBy(How = How.LinkText, Using = "My Account")]
        public IWebElement MyAccount { get; set; }

        // Verificando elementos tela reportar problemas
        [FindsBy(How = How.Name, Using = "category_id")]
        public IWebElement category_id { get; set; }

        [FindsBy(How = How.Name, Using = "reproducibility")]
        public IWebElement reproducibility { get; set; }

        [FindsBy(How = How.Name, Using = "severity")]
        public IWebElement severity { get; set; }

        [FindsBy(How = How.Name, Using = "priority")]
        public IWebElement priority { get; set; }

        [FindsBy(How = How.Name, Using = "profile_id")]
        public IWebElement profile_id { get; set; }

        [FindsBy(How = How.Name, Using = "summary")]
        public IWebElement summary { get; set; }

        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement description { get; set; }

        [FindsBy(How = How.Name, Using = "steps_to_reproduce")]
        public IWebElement steps_to_reproduce { get; set; }

        [FindsBy(How = How.Name, Using = "additional_info")]
        public IWebElement additional_info { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button")]
        public IWebElement InputButton { get; set; }
    }
}
