using BoDi;
using MarsQASpecFlowProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsQASpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        /*private readonly IObjectContainer _container;
        public static IWebDriver driver;

        public object TimeUnit { get; private set; }

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            //launch turnup portal
            driver.Manage().Window.Maximize();
            //launch turnup portal
           // driver.Navigate().GoToUrl("http://localhost:5000/");
            _container.RegisterInstanceAs<IWebDriver>(driver);
          

        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve <IWebDriver> ();

            if(driver != null)
            {
                driver.Quit();
            }
        }*/
        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            Initialize();
        }


        [AfterScenario]
        public void AfterSCenario()
        {
            Close();
        }
    }
}