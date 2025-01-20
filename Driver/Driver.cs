using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.StepDefinitions
{
    public static class DriverSetup
    {
        private static IPage _page;
        private static IBrowser _browser;

        public static async Task<IPage> GetPageAsync()
        {
            if (_page == null)
            {
                var playwright = await Playwright.CreateAsync();
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
                var context = await _browser.NewContextAsync();
                _page = await context.NewPageAsync();
            }
            return _page;
        }

        public static async Task CloseBrowserAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
                _page = null;
            }
        }
    }
}