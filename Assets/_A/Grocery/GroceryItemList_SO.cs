
using UnityEngine;

[CreateAssetMenu(fileName = "GroceryItemList", menuName = "Data/Grocery/GroceryItemList_SO")]
public class GroceryItemList_SO : ScriptableObject
{
    public string GroceryItemListName;
    public GroceryItem_SO[] GroceryItems;
}