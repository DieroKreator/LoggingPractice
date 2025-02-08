namespace AutomationPractice;

[TestClass]
[TestCategory("ContactUsPage")]
public class ContactUsFeature : BaseTest
{
    [TestMethod]
    [Description("Validate that the contact us page opens successfully with a form.")]
    [TestProperty("Author", "Diego Rojas")]
    public void TCID2()
    {
        ContactUsPage contactUsPage = new ContactUsPage(Driver);
        contactUsPage.GoTo();
        Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully");
    }
}