using UnityEngine;

public abstract class IntSetting : BaseSetting<int>
{
  public override int Get()
  {
    return PlayerPrefs.GetInt(GetIdentifier(), GetDefaultValue());
  }

  public override void Set(int newValue)
  {
    PlayerPrefs.SetInt(GetIdentifier(), newValue);
  }
}
