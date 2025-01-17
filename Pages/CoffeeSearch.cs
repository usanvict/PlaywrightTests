using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CoffeeSearch
{
    private IPage _page;
    private readonly ILocator _coffeeButton;
    private readonly ILocator _searchField;
    private readonly ILocator _completeResults;
    private readonly ILocator _filterCoffeeTab;
    public CoffeeSearch(IPage page)
    {
        _page = page;
        _coffeeButton = _page.Locator("#navbar").GetByRole(AriaRole.Link, new() { Name = "Káva" });
        _searchField = _page.Locator("#front_search_inp_lg");
        _completeResults = _page.Locator("#search_complete_results");
        _filterCoffeeTab = _page.Locator("#filterTab");

    }

    public async Task ClickCoffee() => await _coffeeButton.ClickAsync();

    public async Task LookForSomething(String something)
    {
        await _searchField.PressSequentiallyAsync(something);
    }

    public async Task<bool> VerifyCoffeeIsClicked()
    {
        var actualText = await _filterCoffeeTab.TextContentAsync();
        return string.Equals(actualText, "Káva");

    }
}