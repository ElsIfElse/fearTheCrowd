using System;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroceryInventoryView
{
    Transform _playerGroceryItemParentTransform;

    public void Initialize(PlayerGroceryInventoryViewData data)
    {
        _playerGroceryItemParentTransform = data.PlayerGroceryItemParentTransform;
    }
    public void AddItem(GroceryTaskItem groceryTaskItem)
    {
        groceryTaskItem.gameObject.transform.SetParent(_playerGroceryItemParentTransform, false);
        groceryTaskItem.gameObject.SetActive(true);
    }

    public void RemoveItem(GroceryTaskItem groceryTaskItem)
    {
        GameObject.Destroy(groceryTaskItem.gameObject);
    }
}

[Serializable]
public struct PlayerGroceryInventoryViewData
{
    public Transform PlayerGroceryItemParentTransform;
}