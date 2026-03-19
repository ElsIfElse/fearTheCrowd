
using System;
using System.Collections.Generic;
using UnityEngine;

public class GroceryTaskView
{
    Transform _groceryTaskParentTransform;

    public void InitializeView(GroceryTaskViewData data)
    {
        _groceryTaskParentTransform = data.GroceryTaskParentTransform;
    }

    public void AddGroceryTask(GroceryTaskItem groceryTaskItem)
    {
        groceryTaskItem.gameObject.transform.SetParent(_groceryTaskParentTransform, false);
    }

    // Transform _groceryTaskParentTransform;
    // GroceryItemFactory _groceryItemFactory;

    // List<GroceryTaskItem> _groceryTaskItems = new();

    // public void InitializeHandler(GroceryTaskViewData data)
    // {
    //     _groceryItemFactory = data.GroceryItemFactory;
    //     _groceryTaskParentTransform = data.GroceryTaskParentTransform;
    // }

    // public void AddNewGroceryTask(GroceryItem groceryItem)
    // {
    //     GameObject item = _groceryItemFactory.GetNewGroceryItem(groceryItem.GroceryItemType);
    //     GroceryTaskItem groceryTaskItem = item.GetComponent<GroceryTaskItem>();
    //     groceryTaskItem._groceryItem = groceryItem;
    //     item.transform.SetParent(_groceryTaskParentTransform,false);
    //     _groceryTaskItems.Add(groceryTaskItem);
    // }

    // public GroceryTaskItem RemoveGroceryTask(GroceryItem groceryItem)
    // {
    //     GroceryTaskItem groceryTaskItem = _groceryTaskItems.Find(x => x._groceryItem == groceryItem);
    //     _groceryTaskItems.Remove(groceryTaskItem);
    //     groceryTaskItem.FinishTask();
    //     return groceryTaskItem;
    // }
}

[Serializable]
public struct GroceryTaskViewData
{
    public Transform GroceryTaskParentTransform;
}