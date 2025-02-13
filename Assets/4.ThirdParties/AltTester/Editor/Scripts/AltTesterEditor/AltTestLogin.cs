using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;
using System.Threading;
using System.Collections.Generic;
using System;
using UnityEngine;
public class AltTestLogin
{   
    public AltDriver altDriver;

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver(appName: "TestingProject");
        //altDriver = new AltDriver(host: "192.168.0.195", port: 13000, appName: "TestingProject");
        AltReversePortForwarding.ReversePortForwardingAndroid();
    }

    //Write your tet case for login here

    //At the end of the test closes the connection with the socket

    [Test]
    public void LoginSuccess() {
        System.Collections.Generic.List<string> loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.LoadFirst", loadedSceneNames[0]);
        Assert.AreEqual("Taggle.Login", loadedSceneNames[1]);
        var LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(2000);
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
        var EmailInputField = altDriver.FindObject(By.PATH, "//IpfEmail");
        altDriver.Tap(EmailInputField.GetScreenPosition());
        Thread.Sleep(500);
        EmailInputField.SetText("taggletester");
        Thread.Sleep(500);
        var PassInputField = altDriver.FindObject(By.PATH, "//IpfPassword");
        altDriver.Tap(PassInputField.GetScreenPosition());
        Thread.Sleep(500);
        PassInputField.SetText("Aa123123!@#");
        TestPassWordObfuscate("Aa123123!@#");
        Thread.Sleep(500);
        LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(1000);
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.HomePage", loadedSceneNames[1]);
    }

    [Test]
    public void LoginFailedWrongEmailCorrectPassword()
    {
        System.Collections.Generic.List<string> loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.LoadFirst", loadedSceneNames[0]);
        Assert.AreEqual("Taggle.Login", loadedSceneNames[1]);
        var LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(2000);
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
        var EmailInputField = altDriver.FindObject(By.PATH, "//IpfEmail");
        altDriver.Tap(EmailInputField.GetScreenPosition());
        Thread.Sleep(500);
        string randomEmail = randomString();
        while (randomEmail == "taggletester")
            randomEmail = randomString();
        EmailInputField.SetText(randomEmail);
        Thread.Sleep(500);
        var PassInputField = altDriver.FindObject(By.PATH, "//IpfPassword");
        altDriver.Tap(PassInputField.GetScreenPosition());
        Thread.Sleep(500);
        PassInputField.SetText("Aa123123!@#");
        TestPassWordObfuscate("Aa123123!@#");
        Thread.Sleep(500);
        LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(500);
        var TextError = altDriver.FindObject(By.NAME, "TxtError");
        Assert.AreEqual("Username or password is incorrect", TextError.GetText());
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
    }

    [Test]
    public void LoginCorrectEmailFailedWrongPassWord()
    {
        System.Collections.Generic.List<string> loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.LoadFirst", loadedSceneNames[0]);
        Assert.AreEqual("Taggle.Login", loadedSceneNames[1]);
        var LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(2000);
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
        var EmailInputField = altDriver.FindObject(By.PATH, "//IpfEmail");
        altDriver.Tap(EmailInputField.GetScreenPosition());
        Thread.Sleep(500);
        string randomEmail = randomString();
        while (randomEmail == "taggletester")
            randomEmail = randomString();
        EmailInputField.SetText(randomEmail);
        Thread.Sleep(500);
        var PassInputField = altDriver.FindObject(By.PATH, "//IpfPassword");
        altDriver.Tap(PassInputField.GetScreenPosition());
        Thread.Sleep(500);
        string randomPass = randomString();
        while (randomPass == "Aa123123!@#") {
            randomPass = randomString();
        }
        PassInputField.SetText(randomPass);
        TestPassWordObfuscate(randomPass);
        Thread.Sleep(500);
        LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(500);
        var TextError = altDriver.FindObject(By.NAME, "TxtError");
        Assert.AreEqual("Username or password is incorrect", TextError.GetText());
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
    }

    [Test]
    public void LoginFailedWrongEmailWrongPassWord()
    {
        System.Collections.Generic.List<string> loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.LoadFirst", loadedSceneNames[0]);
        Assert.AreEqual("Taggle.Login", loadedSceneNames[1]);
        var LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(2000);
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
        var EmailInputField = altDriver.FindObject(By.PATH, "//IpfEmail");
        altDriver.Tap(EmailInputField.GetScreenPosition());
        Thread.Sleep(500);
        EmailInputField.SetText("taggletester");
        Thread.Sleep(500);
        var PassInputField = altDriver.FindObject(By.PATH, "//IpfPassword");
        altDriver.Tap(PassInputField.GetScreenPosition());
        Thread.Sleep(500);
        string randomPass = randomString();
        while (randomPass == "Aa123123!@#")
        {
            randomPass = randomString();
        }
        PassInputField.SetText(randomPass);
        TestPassWordObfuscate(randomPass);
        Thread.Sleep(500);
        LoginBtn = altDriver.FindObject(By.NAME, "BtnLogin");
        altDriver.Tap(LoginBtn.GetScreenPosition());
        Thread.Sleep(500);
        var TextError = altDriver.FindObject(By.NAME, "TxtError");
        Assert.AreEqual("Username or password is incorrect", TextError.GetText());
        loadedSceneNames = altDriver.GetAllLoadedScenes();
        Assert.AreEqual("Taggle.Login.UserName", loadedSceneNames[1]);
    }

    public string randomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=";
        System.Random random = new System.Random();
        int length = random.Next(1, 21); // Random length between 1 and 20

        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    public bool TestPassWordObfuscate(string pass) {
        bool onlyAsterisks = true;
        for (int i = 0; i < pass.Length; i++)
        {
            if (pass[i] != '*')
            {
                Console.WriteLine($"Non-asterisk character '{pass[i]}' found at position {i}");
                onlyAsterisks = false;
            }
        }
        return onlyAsterisks;
    }
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
        AltReversePortForwarding.RemoveReversePortForwardingAndroid();
    }
}