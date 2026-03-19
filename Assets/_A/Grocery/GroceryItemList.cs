using System;
using System.Collections.Generic;
using UnityEngine;

public class GroceryItemList
{
    public Dictionary<GroceryItemType,GroceryItem> GorceryDictionary = new();
    public List<GroceryItem> GroceryItems = new();
    public List<GroceryItem> UsedItems = new();

    public void InitializeGroceryItemList(GroceryItemListData data)
    {
        CreateObjectsFromData(data.GroceryItems);

        Debug.Log($"GroceryItemList is initialized. Grocery List count: [{GroceryItems.Count}]");
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

    /// <summary>
    /// Returns the concrete grocery item of the type
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Grocery Item</returns>
    public GroceryItem GetGroceryItem(GroceryItemType type) => GorceryDictionary[type];

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
            GorceryDictionary.Add(groceryItem.GroceryItemType,groceryItem);
        }
    }
}

[Serializable]
public struct GroceryItemListData
{
    public GroceryItemList_SO GroceryItems;
}