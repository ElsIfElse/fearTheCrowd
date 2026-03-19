
using System;
using System.Collections.Generic;
using UnityEngine;

public class GroceryTaskHandlerView
{
    Transform _groceryTaskParentTransform;
    GroceryItemFactory _groceryItemFactory;

    List<GroceryTaskItem> _groceryTaskItems = new();

    public void InitializeHandler(GroceryTaskHandlerViewData data)
    {
        _groceryItemFactory = data.GroceryItemFactory;
        _groceryTaskParentTransform = data.GroceryTaskParentTransform;
    }

    public void AddNewGroceryTask(GroceryItem groceryItem)
    {
        GameObject item = _groceryItemFactory.GetNewGroceryItem(groceryItem.GroceryItemType);
        GroceryTaskItem groceryTaskItem = item.GetComponent<GroceryTaskItem>();
        groceryTaskItem._groceryItem = groceryItem;
        item.transform.SetParent(_groceryTaskParentTransform,false);
        _groceryTaskItems.Add(groceryTaskItem);
    }

    public void RemoveGroceryTask(GroceryItem groceryItem)
    {
        GroceryTaskItem groceryTaskItem = _groceryTaskItems.Find(x => x._groceryItem == groceryItem);
        _groceryTaskItems.Remove(groceryTaskItem);
        groceryTaskItem.FinishTask();
    }
}

[Serializable]
public struct GroceryTaskHandlerViewData
{
    [HideInInspector] public GroceryItemFactory GroceryItemFactory;
    public Transform GroceryTaskParentTransform;
}