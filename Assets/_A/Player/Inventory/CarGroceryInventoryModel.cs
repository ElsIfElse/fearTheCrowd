using System.Collections.Generic;

public class CarGroceryInventoryModel
{
    List<GroceryTaskItem> _carInventory = new();
    public List<GroceryTaskItem> CarInventory => _carInventory;

    public GroceryTaskItem RemoveItem()
    {
        GroceryTaskItem item = _carInventory[0];
        _carInventory.Remove(item);
        return item;
    }

    public void AddItem(GroceryTaskItem groceryItem)
    {
        _carInventory.Add(groceryItem);
    }
}

