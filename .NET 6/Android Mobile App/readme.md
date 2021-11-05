# Testing an Android application using .NET 6

This project contains a working example of how to test an Android mobile application using SpecFlow and .NET 6.

The project uses [SpecFlow.Actions.Android](https://github.com/SpecFlowOSS/SpecFlow.Actions/tree/main/Plugins/SpecFlow.Actions.Android) to interact with the demo app.

## Pre-requisite steps

1. Android SDK must be installed (recommended that you download [Android studio](https://developer.android.com/studio?gclid=CjwKCAjwiY6MBhBqEiwARFSCPi8TMys4kpMT___7zdDCbgDghY-YIKyWrHJP2uFXfNQcUU2_apL_MRoCznwQAvD_BwE&gclsrc=aw.ds#downloads) which is bundled with the SDK)
2. [Java JRE/JDK](https://www.java.com/en/download/manual.jsp) must be installed
3. The ```JAVA_HOME``` environment variable must be set to your Java JDK folder:

    ```text
    JAVA_HOME=C:\Program Files\Java\jdk-17.0.1
    ```

4. The ```ANDROID_HOME``` environment variable must be set to your Android SDK folder:

    ```text
    ANDROID_HOME=C:\Program Files (x86)\Android\android-sdk
    ```

5. The project should be built as 'release' from the IDE, and the Android app should be started so that the .apk file is generated. You can switch the mode back to debug and close the emulator before you execute the tests.

## Projects

### SpecFlowCalculator

A simple calculator using an Android application. The calculator has basic functionality - Add, subtract, multiply, and divide. This application is the subject under test.

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests in [Calculator.feature](./SpecFlowCalculator.Specs/Features/Calculator.feature) and step definitions defined in [CalculatorStepDefinitions.cs](./SpecFlowCalculator.Specs/Steps/CalculatorStepDefinitions.cs).
