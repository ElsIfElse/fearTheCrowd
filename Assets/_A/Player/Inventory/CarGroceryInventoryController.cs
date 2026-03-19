using System;

public class CarGroceryInventoryController
{
    CarGroceryInventoryModel _carGroceryInventoryModel;
    CarGroceryInventoryView _carGroceryInventoryView;

    public void InitializeController(CarGroceryInventoryControllerData data)
    {
        _carGroceryInventoryModel = new CarGroceryInventoryModel();
        _carGroceryInventoryView = new CarGroceryInventoryView();

        _carGroceryInventoryView.Initialize(data._carGroceryInventoryViewData);
    }

    public void AddItemToInventory(GroceryTaskItem groceryTaskItem)
    {
        _carGroceryInventoryModel.AddItem(groceryTaskItem);
        _carGroceryInventoryView.AddItem(groceryTaskItem);
    }
    public void RemoveItemFromInventory(GroceryTaskItem groceryTaskItem)
    {
        GroceryTaskItem taskItem = _carGroceryInventoryModel.RemoveItem();
        _carGroceryInventoryView.RemoveItem(taskItem);
    }
    public void RemoveAllItemFromInventory()
    {
        foreach(GroceryTaskItem item in _carGroceryInventoryModel.CarInventory)
        {
            RemoveItemFromInventory(item);
        }
    }
}
[Serializable]
public struct CarGroceryInventoryControllerData
{
    public CarGroceryInventoryViewData _carGroceryInventoryViewData;
}