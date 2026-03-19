using System;
using System.Collections.Generic;
using UnityEngine;

public class GroceryCollection
{
    public Dictionary<GroceryItemType,GroceryItem> GroceryDictionary = new();
    public List<GroceryItem> GroceryItems = new();
    public List<GroceryItem> UsedItems = new();

    public void Initialize(GroceryCollectionData data)
    {
        CreateObjectsFromData(data.GroceryItems);
    }

    /// <summary>
    /// Returns a random grocery item and removes it from the available list
    /// </summary>
    /// <returns></returns>
    public GroceryItem GetRandomGroceryItem()
    {
        if(GroceryItems.Count == 0) return null;
        GroceryItem item = GroceryItems[UnityEngine.Random.Range(0, GroceryItems.Count)]; 
        GroceryItems.Remove(item);
        UsedItems.Add(item);
        Debug.Log($"Created random grocery item in factory [{item.GroceryItemName}]");
        return item;
    }

    public void ResetItems()
    {
        if(UsedItems.Count == 0) return;
        foreach (GroceryItem item in UsedItems)
        {
            GroceryItems.Add(item);
        }

        UsedItems.Clear();
    }

    void CreateObjectsFromData(GroceryItemList_SO groceryItemList_SO)
    {
        foreach(GroceryItem_SO itemData in groceryItemList_SO.GroceryItems)
        {
            GroceryItem groceryItem = new(itemData);
            GroceryItems.Add(groceryItem);
            GroceryDictionary.Add(groceryItem.GroceryItemType,groceryItem);
        }
    }
}

[Serializable]
public struct GroceryCollectionData
{
    public GroceryItemList_SO GroceryItems;
}