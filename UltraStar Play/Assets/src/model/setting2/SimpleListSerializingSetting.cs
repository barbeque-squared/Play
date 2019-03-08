using System;
using System.Collections.Generic;
using UnityEngine;

// the fact that this also implements IList<T> is commented because the Enumerators are strange
public abstract class SimpleListSerializingSetting<T> : SimpleSerializingSetting<List<T>> //, IList<T>
{
  private List<T> _list;

  protected SimpleListSerializingSetting()
  {
    _list = Get();
  }

  // IList<T> properties
  public T this[int index]
  {
    get
    {
      return _list[index];
    }
    set
    {
      _list[index] = value;
      Set(_list);
    }
  }

  // IList<T> methods
  public int IndexOf(T item)
  {
    return _list.IndexOf(item);
  }

  public void Insert(int index, T item)
  {
    _list.Insert(index, item);
    Set(_list);
  }

  public void RemoveAt(int index)
  {
    _list.RemoveAt(index);
    Set(_list);
  }

  // ICollection<T> properties
  public int Count
  {
    get
    {
      return _list.Count;
    }
  }

  public bool IsReadOnly
  {
    get
    {
      return false;
    }
  }

  // ICollection<T> methods
  public void Add(T item)
  {
    _list.Add(item);
    Set(_list);
  }

  public void Clear()
  {
    _list.Clear();
    Set(_list);
  }

  public bool Contains(T item)
  {
    return _list.Contains(item);
  }

  public void CopyTo(T[] array, int index)
  {
    _list.CopyTo(array, index);
  }

  public bool Remove(T item)
  {
    bool res = _list.Remove(item);
    if (res)
    {
      Set(_list);
    }
    return res;
  }

  // IEnumerable methods -- commented because it really doesn't work
  /*
  public IEnumerator<T> GetEnumerator()
  {
    for (int index = 0; index < Count; index++)
    {
      yield return _list[index];
    }
    //return _list.GetEnumerator();
  }
  
  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
  */
}
