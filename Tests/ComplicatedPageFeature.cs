namespace CreatingReports.Tests;

[TestClass]
[TestCategory("ComplicatedPage")]
public class ComplicatedPageFeature : BaseTest
{
    ComplicatedPage ComplicatedPage;
    [TestInitialize]
    public void OpenComplicatedPage()
    {
        ComplicatedPage = new ComplicatedPage(Driver);
        ComplicatedPage.GoTo();
        Assert.IsTrue(ComplicatedPage.IsLoaded, "The complicated page did not open.");
    }

    [TestMethod]
    [TestProperty("Author", "NikolayAdvolodkin")]
    public void TCID6()
    {
        //1. open automation page with many items - https://www.ultimateqa.com/complicated-page/
        //2. Fill out and submit the form in the "Section of random stuff"
        //3. validate that form was submitted successfully

        ComplicatedPage.RandomStuffSection.FillOutFormAndSubmit("my name", "x@x.com", "my message");
        Assert.IsTrue(ComplicatedPage.RandomStuffSection.IsFormSubmitted, "The form was not submitted successfully");

    }
}