using System.Collections.Generic;
using UnityEngine;

public class GrocerySellerManager : MonoBehaviour
{
    #region Singleton
    public static GrocerySellerManager Instance;
    void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public List<GrocerySellerController> GrocerySellers = new();

    public void RegisterGrocerySeller(GrocerySellerController grocerySeller)
    {
        if(GrocerySellers.Contains(grocerySeller)) return;
        GrocerySellers.Add(grocerySeller);
    }
    public void UnRegisterGrocerySeller(GrocerySellerController grocerySeller)
    {
        if(GrocerySellers.Contains(grocerySeller))
        {
            GrocerySellers.Remove(grocerySeller);    
        }
    }

    public void ActivateSellers(List<GroceryTaskItem> groceryTaskItems)
    {
        foreach(GrocerySellerController seller in GrocerySellers) seller.DeActivateGrocerySeller();
        List<GrocerySellerController> sellersToActivate = new();

        foreach(GroceryTaskItem item in groceryTaskItems)
        {
            foreach(GrocerySellerController seller in GrocerySellers)
            {
                if(seller.GroceryItemType == item._groceryItem.GroceryItemType) sellersToActivate.Add(seller);
            }
        }

        foreach(GrocerySellerController seller in sellersToActivate) seller.ActivateGrocerySeller();
    }
}