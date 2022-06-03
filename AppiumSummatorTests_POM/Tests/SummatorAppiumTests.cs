using AppiumSummatorTests_POM.Window;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTests_POM.Tests
{
	public class SummatorAppiumTests
	{
		private WindowsDriver<WindowsElement> driver;
		private AppiumOptions options;
		private AppiumLocalService appiumLocal;

		[OneTimeSetUp]
		public void OpenApp()
		{
			this.options = new AppiumOptions() {PlatformName = "Windows" };
			options.AddAdditionalCapability(MobileCapabilityType.App, @"ENTER THE FULL PATH OF SummatorDesktopApp.exe");
			this.appiumLocal = new AppiumServiceBuilder().UsingAnyFreePort().Build();
			appiumLocal.Start();

			this.driver = new WindowsDriver<WindowsElement>(appiumLocal, options);
		}

		[OneTimeTearDown]
		public void ShutDownApp()
		{
			this.driver.CloseApp();
			driver.Quit();
			this.appiumLocal.Dispose();
		}

		[TestCase("0", "0", "0")]
		[TestCase("5", "5", "10")]
		[TestCase("-5", "-5", "-10")]
		[TestCase("5", "-5", "0")]
		[TestCase("-5", "5", "0")]
		[TestCase("hello", "5", "error")]
		[TestCase("5", "hello", "error")]
		[TestCase("hello", "hello", "error")]
		[TestCase("", "5", "error")]
		[TestCase("5", "", "error")]
		[TestCase("", "", "error")]
		public void Summator_Test(string firstNum, string secondNum, string expectedResult)
		{
			var window = new SummatorWindow(driver);
			var actualResult = window.Calculate(firstNum, secondNum);

			Assert.That(actualResult, Is.EqualTo(expectedResult));
			
		}
	}
}

