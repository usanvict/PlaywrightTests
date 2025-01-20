namespace PlaywrightTests.Steps;

using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;
using PlaywrightTests.Pages;

[Binding]
public class KofioTestSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IPage _page;

    public KofioTestSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }


    [Given(@"I am on the main page")]
    public async Task GoToKofioMainPage()
    {
        CoffeeSearch coffeeSearchPage = new(_page);
        await coffeeSearchPage.GoToKofio();
    }

    [When(@"I click on Tab Coffee")]
    public async Task CheckIfHasCoffee()
    {
        CoffeeSearch coffeeSearchPage = new(_page);
        await coffeeSearchPage.SkipImages();
        await coffeeSearchPage.ClickCoffee();
    }

    [Then(@"I can see Tab Coffee opened")]
    public async Task CheckIfTabIsOpened(string tabType)
    {
        CoffeeSearch coffeeSearchPage = new(_page);
        await coffeeSearchPage.VerifyTabText("Káva");
    }
}
