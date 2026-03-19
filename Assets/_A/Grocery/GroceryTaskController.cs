using System;

public class GroceryTaskController
{
    GroceryTaskModel _groceryTaskHandlerModel;
    GroceryTaskView _groceryTaskHandlerView;

    public void InitializeController(GroceryTaskControllerData data)
    {
        _groceryTaskHandlerModel = new();
        _groceryTaskHandlerView = new();

        _groceryTaskHandlerView.InitializeView(data.GroceryTaskHandlerViewData);
    }
    
    public void AddItemToTasks(GroceryTaskItem groceryTaskItem)
    {
        _groceryTaskHandlerModel.AddGroceryTask(groceryTaskItem);
        _groceryTaskHandlerView.AddGroceryTask(groceryTaskItem);
    }
    public GroceryTaskItem RemoveItemFromTasks(GroceryTaskItem groceryItemTask)
    {
        GroceryTaskItem item = _groceryTaskHandlerModel.RemoveGroceryTask(groceryItemTask);
        return item;
    }

    public GroceryTaskItem FindItemByGroceryType(GroceryItemType groceryItemType)
    {
        return _groceryTaskHandlerModel.FindItemByType(groceryItemType);
    }

    void RemoveAllItemFromTasks()
    {
        
    }

}

[Serializable]
public struct GroceryTaskControllerData
{
    public GroceryTaskViewData GroceryTaskHandlerViewData;
}