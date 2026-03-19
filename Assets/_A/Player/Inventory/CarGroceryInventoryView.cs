using System;
using UnityEngine;

public class CarGroceryInventoryView
{
    Transform _carGroceryItemParentTransform;

    public void Initialize(CarGroceryInventoryViewData data)
    {
        _carGroceryItemParentTransform = data.CarGroceryItemParentTransform;
    }

    public void RemoveItem(GroceryTaskItem groceryTaskItem)
    {
        UnityEngine.Object.Destroy(groceryTaskItem.gameObject);
    }

    public void AddItem(GroceryTaskItem groceryTaskItem)
    {
        groceryTaskItem.gameObject.SetActive(true);
        groceryTaskItem.gameObject.transform.SetParent(_carGroceryItemParentTransform, false);
    }
}

[Serializable]
public struct CarGroceryInventoryViewData
{
    public Transform CarGroceryItemParentTransform;
}