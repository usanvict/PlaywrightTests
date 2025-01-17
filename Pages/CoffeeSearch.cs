using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests.Pages;

public class CoffeeSearch(IPage page) : PageTest
{
    private readonly IPage _page = page;
    private ILocator CoffeeButton => _page.Locator("#navbar").GetByRole(AriaRole.Link, new() { Name = "Káva" });
    public ILocator FilterTab => _page.Locator("#filterTab");

    public async Task ClickCoffee()
    {
        await CoffeeButton.ClickAsync();
        await _page.WaitForURLAsync("**/kava");
    }

    public async Task VerifyTabText(string expectedText)
    {
        await Expect(FilterTab).ToHaveTextAsync(expectedText);
    }

    public async Task CheckStatusIs200()
    {
        var response = await _page.RunAndWaitForResponseAsync(async () =>
        {
            await CoffeeButton.ClickAsync();
        }, x => x.Url.Contains("/kava"));
        Assertions.Equals(response.Status, 200);

    }

}