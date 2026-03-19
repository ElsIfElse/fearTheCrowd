using System;
using System.Collections.Generic;

public class GroceryTaskHandlerModel
{
    GroceryItemList _groceryItemList;
    GroceryTaskHandlerView _groceryTaskHandlerView;

    public List<GroceryItem> CurrentTaskItems = new();

    public void InitializeHandler(GroceryTaskHandlerModelData data)
    {
        _groceryItemList = data.GroceryItemList;
        _groceryTaskHandlerView = data.GroceryTaskHandlerView;
    }    
    public void CreateTaskItems(int numberOfItems)
    {
        for(int i = 0; i < numberOfItems; i++)
        {
            CurrentTaskItems.Add(_groceryItemList.GetRandomGroceryItem());
        }

        foreach(GroceryItem item in CurrentTaskItems) _groceryTaskHandlerView.AddNewGroceryTask(item);
    }

    public void DeactivateItem(GroceryItemType itemType = default)
    {
        foreach(GroceryItem groceryItem in CurrentTaskItems)
        {
            if(groceryItem.GroceryItemType == itemType)
            {
                CurrentTaskItems.Remove(groceryItem);
                _groceryTaskHandlerView.RemoveGroceryTask(groceryItem);
            }

        }
    }
}

[Serializable]
public struct GroceryTaskHandlerModelData
{
    public GroceryItemList GroceryItemList;
    public GroceryTaskHandlerView GroceryTaskHandlerView;
}