using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Grocery Item", menuName = "Data/Grocery/Grocery Item")]
public class GroceryItem_SO : ScriptableObject
{
    public string GroceryItemName;
    public GroceryItemType GroceryItemType;
    public Sprite GroceryIcon;
    public int GroceryItemPrice;
}