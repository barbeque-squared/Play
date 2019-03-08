using System;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class SimpleSettingTest
{
    [Test]
    public void EndsInSetting_SimpleIdentifier()
    {
        TestSetting testSetting = new TestSetting();
        Assert.AreEqual("Test", testSetting.GetIdentifier());
    }

    [Test]
    public void NotEndsInSetting_FullIdentifier()
    {
        TestSetting testSetting = new TestSetting2();
        Assert.AreEqual("TestSetting2", testSetting.GetIdentifier());
    }

    private class TestSetting : SimpleSetting<string>
    {
        public override string Get()
        {
            return "";
        }

        public override void Set(string newValue){}

        public override void Reset(){}
        
        public override string GetDefaultValue()
        {
            return "";
        }
    }

    private class TestSetting2 : TestSetting{}
}
