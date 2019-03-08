using System;
using System.Linq;
using UnityEngine;

public abstract class SimpleSetting<T> : BaseSetting<T>
{
  public abstract void Reset();

  public string GetIdentifier()
  {
    string identifier = this.GetType().Name;
    string suffix = "Setting";
    if (identifier.EndsWith(suffix, StringComparison.Ordinal))
    {
      identifier = identifier.Substring(0, identifier.Length - suffix.Length);
    }
    return identifier;
  }

  public abstract T GetDefaultValue();
}
