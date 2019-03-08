using System;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public abstract class SimpleSerializingSetting<T> : SimpleSetting<T>
{
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
    PlayerPrefs.Save();
  }

  public override void Reset()
  {
    PlayerPrefs.DeleteKey(GetIdentifier());
    PlayerPrefs.Save();
  }

  // protected virtual so that subclasses may override their serialize/unserialize behaviour
  protected virtual string Serialize(T input)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(T));
    StringWriter stringWriter = new StringWriter(new StringBuilder());
    serializer.Serialize(stringWriter, input);
    return stringWriter.GetStringBuilder().ToString();
  }

  protected virtual T Unserialize(string input)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(T));
    using (StringReader reader = new StringReader(input))
    {
      return (T) serializer.Deserialize(reader);
    }
  }
}
