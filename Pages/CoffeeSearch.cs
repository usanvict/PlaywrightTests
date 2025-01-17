using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CoffeeSearch
{
    private IPage _page;
    private readonly ILocator _coffeeButton;
    private readonly ILocator _filterTab;
    public CoffeeSearch(IPage page)
    {
        _page = page;
        _coffeeButton = _page.Locator("#navbar").GetByRole(AriaRole.Link, new() { Name = "Káva" });
        _filterTab = _page.Locator("#filterTab");

    }

    public async Task ClickCoffee() => await _coffeeButton.ClickAsync();

    public async Task<bool> DoesTabContainText(string expectedText)
    {
        try
        {
            var actualText = await _filterTab.InnerTextAsync();
            return actualText.Contains(expectedText);
        }
        catch (Exception)
        {
            return false;
        }
    }

}