using CreatingReports.Pages;

namespace CreatingReports.Tests;

[TestClass]
[TestCategory("SliderFeature"), TestCategory("AutomationPractice")]
public class SliderFeature : BaseTest
{
    [TestMethod]
    [Description("Validate that slider changes images")]
    [TestProperty("Author", "Diego Rojas")]
    public void TCID3()
    {
       HomePage homePage = new HomePage(Driver);
       homePage.GoTo();
       var currentImage = homePage.Slider.CurrentImage;
       homePage.Slider.ClickNextButton();
       var newImage = homePage.Slider.CurrentImage;
       homePage.Slider.AssertThatImageChanged(currentImage, newImage);
    }
}
