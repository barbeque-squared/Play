using System;
using System.Linq;
using UnityEngine;

public abstract class SimpleSetting<T> : BaseSetting<T>
{
  protected override string GetIdentifier()
  {
    string identifier = this.GetType().Name;
    string suffix = "Setting";
    if (identifier.EndsWith(suffix, StringComparison.Ordinal))
    {
      identifier = identifier.Substring(0, identifier.Length - suffix.Length);
    }
    return ConvertCamelCaseToDotCase(identifier);
  }

  private static string ConvertCamelCaseToDotCase(string input)
  {
    return string.Concat(input.Select((x,i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString())); 
  }
}
