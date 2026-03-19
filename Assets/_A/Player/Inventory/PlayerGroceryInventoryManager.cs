using System;
using System.Collections.Generic;

public class PlayerGroceryInventoryManager
{
    PlayerGroceryInventoryController _playerGroceryInventoryController;
    CarGroceryInventoryController _carGroceryInventoryController;

    public void InitializeManager(PlayerGroceryInventoryManagerData data)
    {
        _playerGroceryInventoryController = new();
        _carGroceryInventoryController = new();
        
        _playerGroceryInventoryController.InitializeController(data.PlayerGroceryInventoryControllerData);
        _carGroceryInventoryController.InitializeController(data.CarGroceryInventoryControllerData);
    }

    public void AddGroceryTaskItemToPlayerInventory(GroceryTaskItem groceryTaskItem)
    {
        _playerGroceryInventoryController.AddItem(groceryTaskItem);
    }

    public void MoveAllItemFromPlayerInventoryToCarInventory(GroceryTaskItem groceryTaskItem)
    {
        List<GroceryTaskItem> items =_playerGroceryInventoryController.RemoveAllItemFromInvetory();

        foreach(GroceryTaskItem item in items)
        {
            _carGroceryInventoryController.AddItemToInventory(item);
        }
    }

    public GroceryTaskItem RemoveSingleItemFromPlayerInventory(GroceryTaskItem groceryTaskItem) 
    {
        return _playerGroceryInventoryController.RemoveItem(groceryTaskItem);
    }

    public void ResetInventories()
    {
        _carGroceryInventoryController.RemoveAllItemFromInventory();
        _playerGroceryInventoryController.RemoveAllItemFromInvetory();
    }
}

[Serializable]
public struct PlayerGroceryInventoryManagerData
{
    public CarGroceryInventoryControllerData CarGroceryInventoryControllerData;
    public PlayerGroceryInventoryControllerData PlayerGroceryInventoryControllerData;
}