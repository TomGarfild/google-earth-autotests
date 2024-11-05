using ATFramework2._0;
using ATFramework2._0.Driver;
using ATFramework2._0.Verifications;
using GoogleEarth.AutoTests.Pages;
using TechTalk.SpecFlow;

namespace GoogleEarth.AutoTests.Steps;

[Binding]
public class EarthAboutSteps(IMainPage mainPage, IOutreachPage outreachPage, IWebDriverManager webDriver)
{
    private void Log(string message, LogLevel level = LogLevel.Info, string feature = "Search")
    {
        webDriver.LogWorker.Log(message, level, feature, ScenarioContext.Current.ScenarioInfo.Title);
    }

    private void LogException(Exception ex, string action)
    {
        Log($"Exception during '{action}': {ex.Message}\n{ex.StackTrace}", LogLevel.Error);
    }

    [Given("Navigate to the main page of the app")]
    public void GivenNavigateToTheApp()
    {
        try
        {
            Log("Navigate to the main page of the app");
        }
        catch (Exception ex)
        {
            LogException(ex, "Navigating to the start page");
            throw;
        }
    }

    [Given("Click on the search")]
    public void GivenClickOnTheSearch()
    {
        try
        {
            Log("Clicking on the search.");

            // mainPage.ClickSearch();
        }
        catch (Exception ex)
        {
            LogException(ex, $"Clicking search");
            throw;
        }
    }

    [When(@"Select More ""(.*)""")]
    public void GivenSelectSalutation(string moreName)
    {
        try
        {
            Log($"Selecting more: {moreName}.");
            mainPage.SelectMore(moreName);
        }
        catch (Exception ex)
        {
            LogException(ex, $"Selecting more '{moreName}'");
            throw;
        }
    }

    [Given(@"Enter text ""(.*)""")]
    public void EnterTextToSearch(string text)
    {
        try
        {
            Log($"Entering '{text}' into the search.");
            // mainPage.InputSearchText(text);
        }
        catch (Exception ex)
        {
            LogException(ex, "Entering text into search");
            throw;
        }
    }

    [Then(@"Header ""(.*)"" is displayed")]
    public void ThenSuccessMessageIsDisplayed(string expText)
    {
        try
        {
            Log($"Verifying header: '{expText}'.");
            VerifyWorker.Equals(
                exp: expText,
                act: () => outreachPage.GetHeader(),
                message: $"Current header should be '{expText}'"
            );
        }
        catch (Exception ex)
        {
            LogException(ex, $"Verifying headere '{expText}'");
            throw;
        }
    }
}