using CreatingReports.Pages;

namespace CreatingReports.Tests;

[TestClass]
[TestCategory("SearchingFeature")]
public class SearchFunctionality : BaseTest
{
    [TestMethod]
    [Description("Checks to make sure that if we search for browser, that browser comes back")]
    [TestProperty("Author", "Diego Rojas")]
    public void TCID1()
    {
        string stringToSearch = "blouse";

        var homePage = new HomePage(Driver);
        homePage.GoTo();
        var searchPage = homePage.Search(stringToSearch);
        Assert.IsTrue(searchPage.Contains(Item.Blouse),
            $"When searching for the string=>{stringToSearch}, " +
            $"we did not find it in the search results.");
    }
}
