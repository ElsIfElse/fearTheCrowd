using System.Collections.Generic;

public  class PlayerGroceryInventoryModel
{
    List<GroceryTaskItem> _groceryInHandInventory = new();
    public List<GroceryTaskItem> GroceryInHandInventory => _groceryInHandInventory;

    public void AddItem(GroceryTaskItem groceryItem)
    {
        _groceryInHandInventory.Add(groceryItem);
    }
    public GroceryTaskItem RemoveItem(GroceryTaskItem groceryItem)
    {
        GroceryTaskItem item = _groceryInHandInventory.Find(x => x._groceryItem.GroceryItemName == groceryItem._groceryItem.GroceryItemName);
        _groceryInHandInventory.Remove(item);
        return item;
    }
}