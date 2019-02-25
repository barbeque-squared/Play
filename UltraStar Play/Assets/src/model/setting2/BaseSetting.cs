using System;
using UnityEngine;

public abstract class BaseSetting<T> : ISetting<T>
{
  public abstract T Get();
  public abstract void Set(T newValue);

  protected abstract string GetIdentifier();
  protected abstract T GetDefaultValue();
}
