using System.Collections.Generic;

public class SongDirectorySetting : SimpleListSerializingSetting<string>
{
  public override List<string> GetDefaultValue()
  {
    return new List<string>();
  }
}
