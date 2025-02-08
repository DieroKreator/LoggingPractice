namespace AutomationPractice;

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
       Assert.AreNotEqual(currentImage, newImage,
           "The slider images did not change when pressing the next button.");
    }
}