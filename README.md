This is a test result for my interview for Taggle healthworld QA position.

1. The test cases are written in the file under path: //Assets/4.ThirdParties/AltTester/Editor/Scripts/AltTesterEditor/AltTestLogin.cs
2. Each test case starts from the beginning of the app. Please restart the app after every test case.
3. AltTester Desktop needs to be launched before testing.
4. For editor testing, in AltTestLogin.cs, please change the host value to your current wifi IP address. After pressing Play in Editor in AltTester@Editor window, in AltTester popup, you need to change the app name to TestingProject. After that, you can run the test case.
5. For Android testing, please ensure the device is connected to the PC via USB cord. You can install the build I have attached to the email or build it yourself with Build Only in Android tab. After launching the build, you need to change the appname, host value, port gate to the correct value for the test to run. Open cmd on Windows or terminal on Macbook, run ```adb reverse TCP:13000 TCP:13000``` to connect the build to AltServer. You can run the test case. 
