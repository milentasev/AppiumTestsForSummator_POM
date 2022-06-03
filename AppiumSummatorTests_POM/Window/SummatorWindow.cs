using OpenQA.Selenium.Appium.Windows;

namespace AppiumSummatorTests_POM.Window
{
	public class SummatorWindow
	{
		private readonly WindowsDriver<WindowsElement> driver;

		public SummatorWindow (WindowsDriver<WindowsElement> driver)
		{
			this.driver = driver;
		}

		public WindowsElement firstNumField => driver.FindElementByAccessibilityId("textBoxFirstNum");
		public WindowsElement secondNumField => driver.FindElementByAccessibilityId("textBoxSecondNum");
		public WindowsElement resultField => driver.FindElementByAccessibilityId("textBoxSum");
		public WindowsElement calculateButton => driver.FindElementByAccessibilityId("buttonCalc");

		public string Calculate(string field1, string field2)
		{
			firstNumField.Clear();
			firstNumField.SendKeys(field1);

			secondNumField.Clear();
			secondNumField.SendKeys(field2);

			calculateButton.Click();

			return resultField.Text;
		}
	}
}

