using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using UnityEngine;

// TODO: also extend the IList<T> interface and implement all the methods
public abstract class SimpleListSerializingSetting<T> : SimpleSetting<List<T>>
{
  private List<T> _list = new List<T>();
  
  protected string Serialize(List<T> input)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
    StringWriter stringWriter = new StringWriter(new StringBuilder());
    serializer.Serialize(stringWriter, input);
    return stringWriter.GetStringBuilder().ToString();
  }
  
  protected List<T> Unserialize(string input)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
    return (List<T>) serializer.Deserialize(new StringReader(input));
  }
  
  public override List<T> Get()
  {
    return Unserialize(
      PlayerPrefs.GetString(
        GetIdentifier(),
        Serialize(GetDefaultValue())
      )
    );
  }

  public override void Set(List<T> newValue)
  {
    PlayerPrefs.SetString(
      GetIdentifier(),
      Serialize(newValue)
    );
  }

  public void Add(T item)
  {
    _list = Get();
    _list.Add(item);
    Set(_list);
  }

  public bool Remove(T item)
  {
    _list = Get();
    bool res = _list.Remove(item);
    if (res)
    {
      Set(_list);
    }
    return res;
  }
}
