using System;

public abstract class SimpleEnumSetting<T> : SimpleSerializingSetting<T>
{
  
  protected override string Serialize(T input)
  {
    return input.ToString();
  }
  
  protected override T Unserialize(string input)
  {
    return ParseEnum(input);
  }

  private static T ParseEnum(string value)
  {
    return (T) Enum.Parse(typeof(T), value, true);
  }
}
