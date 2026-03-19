using System;
using System.Collections.Generic;

public class GroceryTaskModel
{
    List<GroceryTaskItem> _groceryTasks = new();

    public GroceryTaskItem RemoveGroceryTask(GroceryTaskItem groceryTaskItem)
    {
        GroceryTaskItem item = _groceryTasks.Find(x => x._groceryItem == groceryTaskItem._groceryItem);
        _groceryTasks.Remove(item);
        return item;
    }

    public void AddGroceryTask(GroceryTaskItem groceryTaskItem)
    {
        _groceryTasks.Add(groceryTaskItem);
    }

    public List<GroceryTaskItem> RemoveAllGroceryTasks()
    {
        if(_groceryTasks.Count == 0) return null;

        List<GroceryTaskItem> groceryTaskItems = new(_groceryTasks);
        foreach(GroceryTaskItem item in groceryTaskItems)
        {
            RemoveGroceryTask(item);
        }

        return groceryTaskItems;
    }

    public GroceryTaskItem FindItemByType(GroceryItemType groceryItemType)
    {
        return _groceryTasks.Find(x => x._groceryItem.GroceryItemType == groceryItemType);
    }

    // GroceryItemList _groceryItemList;
    // GroceryTaskView _groceryTaskHandlerView;

    // public List<GroceryItem> CurrentTaskItems = new();

    // public void InitializeHandler(GroceryTaskModelData data)
    // {
    //     _groceryItemList = data.GroceryItemList;
    //     _groceryTaskHandlerView = data.GroceryTaskHandlerView;
    // }    
    // public void CreateTaskItems(int numberOfItems)
    // {
    //     for(int i = 0; i < numberOfItems; i++)
    //     {
    //         CurrentTaskItems.Add(_groceryItemList.GetRandomGroceryItem());
    //     }

    //     foreach(GroceryItem item in CurrentTaskItems) _groceryTaskHandlerView.AddNewGroceryTask(item);
    // }

    // public void DeactivateItem(GroceryItemType itemType = default)
    // {
    //     Debug.Log($"Deactivate item: [{itemType}]");
    //     if(itemType == default) Debug.Log($"ItemType is default");
    //     if(CurrentTaskItems.Count == 0) Debug.Log($"CurrentTaskItems is empty");

    //     foreach(GroceryItem groceryItem in CurrentTaskItems)
    //     {
    //         if(groceryItem.GroceryItemType == itemType)
    //         {
    //             PlayerManager.Instance.PlayerGroceryInventoryManager.MoveItemFromSellerToPlayerInventory(_groceryTaskHandlerView.RemoveGroceryTask(groceryItem));
    //             CurrentTaskItems.Remove(groceryItem);
    //             return;
    //         }
    //     }
    // }
}