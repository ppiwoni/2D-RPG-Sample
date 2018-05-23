using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 48;  

    public List<Item> items = new List<Item>();

    public int PlayerGold { get; protected set; }

    public void ManageGold(int gold)
    {

        PlayerGold += gold;

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

    }

    public void Add(Item item)
    {
       
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        
    }

    

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
