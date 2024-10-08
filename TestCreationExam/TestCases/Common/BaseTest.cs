using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestCreationExam.TestCases.Common
{
    public abstract class BaseTest
    {
        public ThreadLocal<IWebDriver> Driver = new();
        public string Url = string.Empty;

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            Url = "https://the-internet.herokuapp.com/challenging_dom"; 
            Url = "https://demoqa.com/automation-practice-form";
        }

        [SetUp]
        public virtual void Setup()
        {
            Driver.Value = new ChromeDriver();
            Driver.Value.Manage().Window.Maximize();
            Driver.Value.Url = Url;
        }

        [TearDown]
        public virtual void TearDown()
        {
            Driver.Value?.Quit();
        }
    }
}