using System;

public abstract class SimpleEnumSetting<T> : SimpleSerializingSetting<T>
{
  protected override string Serialize(T input)
  {
    if (input == null)
    {
      throw new ArgumentNullException("input");
    }
    return input.ToString();
  }
  
  // Enums are a bit tricky as their saved state may not be valid anymore
  // this changes the Unserialize behaviour to do some additional checks
  // and do some housekeeping if necessary
  protected override T Unserialize(string input)
  {
    if (Enum.IsDefined(typeof(T), input))
    {
      return (T) Enum.Parse(typeof(T), input, false);
    }
    else
    {
      Reset();
      return GetDefaultValue();
    }
  }
}
