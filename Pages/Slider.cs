using OpenQA.Selenium;

namespace CreatingReports.Pages;

public class Slider : BaseApplicationPage
{
    public Slider(IWebDriver driver) : base(driver) { }

    public object CurrentImage => MainSliderImage.GetAttribute("style");

    private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));

    internal void ClickNextButton()
    {
        Driver.FindElement(By.ClassName("bx-next")).Click();
    }
}
