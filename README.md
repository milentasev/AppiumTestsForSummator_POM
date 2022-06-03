# AppiumTestsForSummator_POM
## This repository contains UI automated tests for the Summator Desktop аpp using Page Object Model design pattern.
Instrinctions:
* Download the SummatorDesktopApp.exe
* Enter the full path to the app in the following row in the 'SetUp' of SummatorAppiumTests.cs: options.AddAdditionalCapability(MobileCapabilityType.App, @"ENTER THE PATH TO THE SummatorDesktopApp.exe")
