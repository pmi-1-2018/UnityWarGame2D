using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsBag : MonoBehaviour, IList<GameObject>
{
    private List<GameObject> data;

    public GameObject this[int index]
    {
        get
        {
            if (index >= 0 && index < data.Count)
            {
                return data[index];
            }
            else
            {
                Debug.Log("WRONG INDEX IN ARTIFACTS BAG");
                return null;
            }
        }
        set
        {
            if (index >= 0 && index < data.Count && !Contains(value))
            {
                data[index] = value;
            }
            else
            {
                Debug.Log($"WRONG INDEX IN ARTIFACTS BAG OR ALREADY CONTAINS: {value.name}");
            }
        }
    }

    public ArtifactsBag()
    {
        data = new List<GameObject>();
    }

    public int Count => data.Count;

    public bool IsReadOnly => false;

    public void Add(GameObject item)
    {
        if(!Contains(item))
        {
            data.Add(item);
        }
        else
        {
            Debug.Log($"ALREADY CONTAINS THIS ITEM: {item.name}");
        }
    }

    public void Clear()
    {
        data.Clear();
    }

    public bool Contains(GameObject item)
    {
        return data.Contains(item);
    }

    public void CopyTo(GameObject[] array, int arrayIndex)
    {
        data.CopyTo(array, arrayIndex);
    }

    public IEnumerator<GameObject> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    public int IndexOf(GameObject item)
    {
        return data.IndexOf(item);
    }

    public void Insert(int index, GameObject item)
    {
        if(!Contains(item))
        {
            data.Insert(index, item);
        }
        else
        {
            Debug.Log($"ALREADY CONTAINS THIS ITEM: {item.name}");
        }
    }

    public bool Remove(GameObject item)
    {
        return data.Remove(item);
    }

    public void RemoveAt(int index)
    {
        data.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.GetEnumerator();
    }
}
