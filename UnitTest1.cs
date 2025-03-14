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
        CoffeeSearch coffeeSearchPage = new(Page);
        await coffeeSearchPage.GoToKofio();
    }

    [Skip]
    public async Task HasTitle()
    {
        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Kofio"));
        //For a strcit equation, remove Regex
    }

    //Test made with POM
    [Test]
    public async Task HasCoffee()
    {
        CoffeeSearch coffeeSearchPage = new(Page);
        await coffeeSearchPage.SkipImages();
        await coffeeSearchPage.ClickCoffee();
        await coffeeSearchPage.VerifyTabText("Káva");

    }

    [Skip]
    public async Task HasCoffeeNetwork()
    {
        CoffeeSearch coffeeSearchPage = new(Page);
        await coffeeSearchPage.CheckStatusIs200();
    }

    //Test made without POM
    [Skip]
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
