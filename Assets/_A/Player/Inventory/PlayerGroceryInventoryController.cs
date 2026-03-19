using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroceryInventoryController
{

    PlayerGroceryInventoryModel _playerGroceryInventoryModel;
    PlayerGroceryInventoryView _playerGroceryInventoryView;

    public PlayerGroceryInventoryControllerData PlayerGroceryInventoryControllerData;

    public void InitializeController(PlayerGroceryInventoryControllerData data)
    {
        _playerGroceryInventoryModel = new PlayerGroceryInventoryModel();
        _playerGroceryInventoryView = new PlayerGroceryInventoryView();

        _playerGroceryInventoryView.Initialize(data.PlayerGroceryInventoryViewData);
    }

    public void AddItem(GroceryTaskItem groceryItem)
    {
        _playerGroceryInventoryModel.AddItem(groceryItem);
        _playerGroceryInventoryView.AddItem(groceryItem);
    }

    public GroceryTaskItem RemoveItem(GroceryTaskItem groceryItem)
    {
        _playerGroceryInventoryView.RemoveItem(groceryItem);
        return _playerGroceryInventoryModel.RemoveItem(groceryItem);
    }

    public List<GroceryTaskItem> RemoveAllItemFromInvetory()
    {
        List<GroceryTaskItem> groceryTaskItems = new(_playerGroceryInventoryModel.GroceryInHandInventory);

        foreach(GroceryTaskItem item in groceryTaskItems)
        {
            _playerGroceryInventoryModel.RemoveItem(item);
            _playerGroceryInventoryView.RemoveItem(item);
        }

        return groceryTaskItems;
    }
}

[Serializable]
public struct PlayerGroceryInventoryControllerData
{
    public PlayerGroceryInventoryViewData PlayerGroceryInventoryViewData;
}
