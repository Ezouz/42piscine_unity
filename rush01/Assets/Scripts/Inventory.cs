using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found !");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public List<RandomWeapon> items = new List<RandomWeapon>();
    public int space = 12;

    public bool Add(RandomWeapon item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(int index)
    {
        items.RemoveAt(index);

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
    public void Remove(RandomWeapon wp)
    {
        items.Remove(wp);

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
