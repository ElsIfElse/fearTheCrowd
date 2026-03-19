using UnityEngine;

public class GroceryItem
{
    public GroceryItem(GroceryItem_SO groceryItem_SO)
    {
        GroceryItemName = groceryItem_SO.GroceryItemName;
        GroceryItemType = groceryItem_SO.GroceryItemType;
        GroceryIcon = groceryItem_SO.GroceryIcon;
        GroceryItemPrice = groceryItem_SO.GroceryItemPrice;
    }

    public string GroceryItemName;
    public GroceryItemType GroceryItemType;
    public Sprite GroceryIcon;
    public int GroceryItemPrice;
}