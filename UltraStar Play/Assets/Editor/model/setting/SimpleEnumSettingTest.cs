using System;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class SimpleEnumSettingTest
{
    private TestEnumSetting enumSetting;

    [SetUp]
    public void SetUp()
    {
        enumSetting = new TestEnumSetting();
    }

    [TearDown]
    public void TearDown()
    {
        enumSetting.Reset();
    }

    [Test]
    public void NeverUsed_NothingWritten()
    {
        Assert.IsFalse(PlayerPrefs.HasKey(enumSetting.GetIdentifier()));
    }

    [Test]
    public void NeverWritten_DefaultValueIsReturned()
    {
        Assert.AreEqual(TestEnum.SomeValue, enumSetting.Get());
    }

    [Test]
    public void AfterSet_ConfigWritten()
    {
        enumSetting.Set(TestEnum.SomeValue);

        Assert.IsTrue(PlayerPrefs.HasKey(enumSetting.GetIdentifier()));
        Assert.AreEqual("SomeValue", PlayerPrefs.GetString(enumSetting.GetIdentifier()));
    }

    [Test]
    public void WhenConfigured_ConfigRead()
    {
        PlayerPrefs.SetString(enumSetting.GetIdentifier(), "AnotherValue");

        Assert.AreEqual(TestEnum.AnotherValue, enumSetting.Get());
    }

    [Test]
    public void WhenReset_ConfigCleared()
    {
        PlayerPrefs.SetString(enumSetting.GetIdentifier(), "AnotherValue");

        enumSetting.Reset();

        Assert.IsFalse(PlayerPrefs.HasKey(enumSetting.GetIdentifier()));
    }

    [Test]
    public void WhenWronglyConfigured_ConfigResetAndDefaultValueReturned()
    {
        PlayerPrefs.SetString(enumSetting.GetIdentifier(), "WrongValue");

        TestEnum myTest = enumSetting.Get();

        Assert.AreEqual(TestEnum.SomeValue, myTest);
        Assert.IsFalse(PlayerPrefs.HasKey(enumSetting.GetIdentifier()));
    }

    private enum TestEnum
    {
        SomeValue,
        AnotherValue
    }

    private class TestEnumSetting : SimpleEnumSetting<TestEnum>
    {
        public override TestEnum GetDefaultValue()
        {
            return TestEnum.SomeValue;
        }
    }
}
