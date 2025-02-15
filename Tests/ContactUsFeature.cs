using CreatingReports.Pages;

namespace CreatingReports.Tests;

[TestClass]
[TestCategory("ContactUsPage")]
public class ContactUsFeature : BaseTest
{
    [TestMethod]
    [Description("Validate that the contact us page opens successfully with a form.")]
    [TestProperty("Author", "Diego Rojas")]
    public void TCID2()
    {
        var contactUsPage = new ContactUsPage(Driver);
        contactUsPage.GoTo();
        Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully");
    }

    [TestMethod]
    [Description("Validate that the contact us page opens when clicking the Contact Us button.")]
    [TestProperty("Author", "Diego Rojas")]
    public void TCID4()
    {
        var homePage = new HomePage(Driver);
        homePage.GoTo();
        Assert.IsTrue(homePage.IsLoaded, "Home page did not open successfully");

        var contactUsPage = homePage.Header.ClickContactUsButton();
        Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully.");

    }
}
