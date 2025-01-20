using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_scenarioContext.ContainsKey("browser"))
            {
                var browser = _scenarioContext.Get<IBrowser>("browser");
                await browser.CloseAsync();
            }
        }
    }
}