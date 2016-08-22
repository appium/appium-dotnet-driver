#Release Notes

##*2.x (under construction yet)*


##2.0.0.1
- All obsolete code was removed. #C client won't support Appium server v lower than 1.5.0
- Source code migration to C# 6.0. Now this bundle requires .Net Framework > v4.5 or Mono Framework version which supports .Net Framework v4.5 with Lang Level 6.
- Update to Selenium.Webdriver v2.53.1 and Selenium.Support v2.53.1.
- Update to Newtonsoft.Json v9.0.1.
- Re-design of mobile searching strategies:
	- The class `OpenQA.Selenium.Appium.MobileBy` was added.
	- Classes `ByAccessibilityId`, `ByAndroidUIAutomator`, `ByIosUIAutomation` were grouped by the new class.
	- Static methods that create instances of `ByAccessibilityId`, `ByAndroidUIAutomator`, `ByIosUIAutomation` were added.
- The method public `W GetNamedTextField(String name)` was marked obsolete. It is going to be removed.	   
- `ScrollTo()` and `ScrollToExact()` became deprecated. They are going to be removed in the next release. The swiping action and `OpenQA.Selenium.Appium.ByAndroidUIAutomator` or
`OpenQA.Selenium.Appium.ByIosUIAutomatio`n are recommended to use instead.
- Server flags were added:
	- `GeneralOptionList.AsyncTrace`
	- `IOSOptionList.WebkitDebugProxyPort`
- The `SessionDetails` property was added.  This property returns a dictionary of the current session data.
- [#153](https://github.com/appium/appium-dotnet-driver/issues/153) fix & [#152](https://github.com/appium/appium-dotnet-driver/issues/152) fix. These changes are supposed to be the temporary workaround. We are searching for a more convenient solution. 
  It seems it requires some changes on the server side.
- FIX of the swiping issue (iOS, server version >= 1.5.0). Now the swiping is implemented differently by AndroidDriver and IOSDriver.
- the ability to start an activity using Android intent actions, intent categories, flags and arguments was added to OpenQA.Selenium.Appium.Android.AndroidDriver. 
The StartActivityWithIntent method.
- [Android] ability to push a common string as a file to the remote mobile device. The method was redesigned.
- [Android] ability to push base64 encoded bytes as a file to the remote mobile device. The method was added.
- [Android] ability to push a file as the file to the remote mobile device. The method was added.
- Constructors like `AppiumDriver(ICommandExecutor commandExecutor, ICapabilities desiredCapabilities)` were added to `OpenQA.Selenium.Appium.Android.AndroidDriver` and `OpenQA.Selenium.Appium.iOS.IOSDriver`. Also 
      `OpenQA.Selenium.Appium.AppiumCommand` became public. The binding of these features may allow to use realated solutions of other vendors/modified Appium server builds which support JSONWP commands 
      that default Appium/Selenium do not support.
- The `SetImmediateValue` method was moved to `OpenQA.Selenium.Appium.AppiumWebElement`. It works against text input elements on Android.

##1.5.1.1
- Update to Selenium.Webdriver v2.53.0 and Selenium.Support v2.53.0
- Update to Newtonsoft.Json v8.0.2
- FIXED The issue of compatibility of AppiumServiceBuilder with Appium node server v >= 1.5.x.
- Page object tools were updated. By.Name locator strategy is deprecated for Android and iOS. It is still valid for the Selendroid mode. 
- The DeviceTime property was added and it works with Appium node 1.5
- improvements of locking methods. The LockDevice(seconds) is obsolete and it is going to be removed in the next release. Since Appium node server v1.5.x it is recommended to use 
AndroidDriver.Lock()()...AndroidDriver.Unlock() or IOSDriver.Lock(int seconds) instead.
- AndroidDriver.KeyEvent() is obsolete and it is going to be removed soon. Please use AndroidDriver.PressKeyCode or AndroidDriver.LongPressKeyCode instead.
- The GetAppStrings(string language = null) method is obsolete now. It is going to be removed. 
- The  GetAppStringDictionary(string language = null, string stringFile = null) was added instead. It returns a dictionary with app strings (keys and values) instead of a string.
Also it allows the searching app strings in the specified file.
- All capabilities were added according to https://github.com/appium/appium/blob/1.5/docs/en/writing-running-appium/caps.md. There are three classes: 
	OpenQA.Selenium.Appium.Enums.MobileCapabilityType (just modified), 
	OpenQA.Selenium.Appium.Enums.AndroidMobileCapabilityType (android-specific capabilities), 
	OpenQA.Selenium.Appium.Enums.IOSMobileCapabilityType (iOS-specific capabilities).
- Some server flags were marked as obsolete because they are deprecated since server node v1.5.x. These options are going to be removed at the next .Net client release.
- The ability to start Appium node programmatically using desired capabilities. This feature is compatible with Appium node server v >= 1.5.x.

##1.5.0.1
- Update to Selenium.Webdriver v2.48.2 and Selenium.Support v2.48.2
- The ability to start appium server programmatically was provided. The ICommandServer implementation (AppiumLocalService).
- The new boolean parameter of the AndroidDdriver.StartActivity method. It allows to start a new activity without closing of a target app.
- All possible key codes were added to AndroidKeyCode.
- The API refactoring.
- The "ReplaceValue" method was added to AndroidElement
- The "SetImmediateValue" was moved from the AppiumWebElement to IOSElement

##1.4.1.1
- Update to Selenium.Webdriver v2.48.1 and Selenium.Support v2.48.1
- .Net client is completely following the Apache 2.0 license now.
- IMobileElement implementations are able to perform gestures such as Pinch, Tap and Zoom.	
- Constructor set of MultiAction and TouchAction was improved. Redundant constructors were removed.

## 1.4.0.3
- the bug which prevented the using of TouchAction/MultiTouchActions with IWebElement was fixed. This problem is reproduced with 
IWebElement instances created via Selenium PageFactory.

## 1.4.0.2

- features ported from the Java-Appium-Driver
	AppiumDriver:

		Tap
		Swipe
		Pinch
		Zoom
		ScrollTo
		ScrollToExact
	
	IOSDriver

		GetNamedTextField
		
	IOSElement

		also ScrollTo & ScrollToExact implementations with extra parameter for a resource ID to 
		scroll on a particular View.
		
- Integration with Selenium PageFactory. Now it is possible to develop UI tests using Page Object design pattern


## 1.3.0.1
- Generic AppiumDriver class and subclasses
- Fixes for backward compatabliltiy for TryAddCommand

## 1.2.0.8
- Fix and add tests for Hide Keyboard

## 1.2.0.7
- Improved namespaces.
- Fixed tests
- Redesigned methods and interfaces.
- Separate android and ios drivers.

## 1.2.0.6
- Update NuGet packages  - fixes locator strategy bug.

## 1.2.0.5
- Add GetSettings and IgnoreUnimportantViews methods.

## 1.2.0.4
- Update version to match assembly and NuGet package
 
## 1.2.0.3
- Needed to update version due to mismanaged NuGet Package.

## 1.2.0.2
- Update Newtonsoft.Json and WebDriver packages
- Add IsLocked Method
- Add Start Activity 

## 1.2.0.1

- Update for new Selenium version
- hideKeyboard update
- Add network connection methods
- Add android input methods
- Add PullFolder command

## 1.0.0

- Reorganized project
- TouchAction/MultiAction rewritting
- Added sample
 
