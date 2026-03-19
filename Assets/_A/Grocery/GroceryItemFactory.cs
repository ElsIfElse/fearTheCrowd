using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroceryItemFactory : MonoBehaviour
{
    public Dictionary<GroceryItemType, GroceryItem> GroceryItems = new();
    public GameObject _groceryTaskItemPrefab;
    GroceryItemList _groceryItemList;

    void CreateFactoryList(Dictionary<GroceryItemType, GroceryItem> groceryItems)
    {
        GroceryItems.AddRange(groceryItems);
    }
    public void InitializeFactory(GroceryItemFactoryData data)
    {
        _groceryItemList = data.GroceryItemList;
        CreateFactoryList(_groceryItemList.GorceryDictionary);
    }
    public GameObject GetNewGroceryItem(GroceryItemType groceryItemType)
    {
        GameObject newItem = Instantiate(_groceryTaskItemPrefab);
        GroceryTaskItem taskItem = newItem.GetComponent<GroceryTaskItem>();
        taskItem.SetGroceryTaskItemImage(GroceryItems[groceryItemType]);
        return newItem;
    }
}

[Serializable]
public struct GroceryItemFactoryData
{
    [HideInInspector] public GroceryItemList GroceryItemList;
    public GameObject GroceryTaskItemPrefab;
}