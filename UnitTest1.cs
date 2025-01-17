﻿using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]

public class Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        //If I'm not happy with timeouts, I can change it here
        // Page.SetDefaultTimeout(3000);
        await Page.GotoAsync("https://kofio.cz", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
    }

    [Test]
    public async Task HasTitle()
    {
        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Kofio"));
        //For a strcit equation, remove Regex
    }

    [Test]
    public async Task HasCoffee()
    {
        CoffeeSearch coffeeSearchPage = new CoffeeSearch(Page);
        await coffeeSearchPage.ClickCoffee();
        await coffeeSearchPage.VerifyCoffeeIsClicked();
    }

    [Test]
    public async Task LookForHAYB()
    {
        var searchFiled = Page.Locator("#front_search_inp_lg");
        await searchFiled.PressSequentiallyAsync("HAYB");
        await Expect(Page.Locator("#search_complete_results")).ToBeVisibleAsync();
        await Expect(Page.Locator("//h5[contains(text(), 'Pražírny')]//..//mark[contains(text(), 'HAYB')]")).ToBeVisibleAsync();
    }


    [Skip]
    public async Task GetStartedLink()
    {
        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}
