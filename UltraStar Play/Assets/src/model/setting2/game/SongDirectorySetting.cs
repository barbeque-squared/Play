using System.Collections.Generic;

public class SongDirectorySetting : SimpleListSerializingSetting<string>
{
  protected override List<string> GetDefaultValue()
  {
    return new List<string>();
  }
}
