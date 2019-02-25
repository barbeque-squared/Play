using System;
using UnityEngine;

public abstract class SimpleSerializingSetting<T> : SimpleSetting<T>
{
  protected abstract string Serialize(T input);
  protected abstract T Unserialize(string input);
  
  public override T Get()
  {
    return Unserialize(
      PlayerPrefs.GetString(
        GetIdentifier(),
        Serialize(GetDefaultValue())
      )
    );
  }

  public override void Set(T newValue)
  {
    PlayerPrefs.SetString(
      GetIdentifier(),
      Serialize(newValue)
    );
  }
}
