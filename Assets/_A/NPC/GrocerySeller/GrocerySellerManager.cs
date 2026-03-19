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

    public void ActivateSellers()
    {
        List<GrocerySellerController> sellersToActivate = new();
        List<GrocerySellerController> sellersToDeactivate = new();

        foreach(GroceryItem groceryItem in GroceryItemManager.Instance.GroceryTaskHandlerModel.CurrentTaskItems)
        {
            foreach(GrocerySellerController seller in  GrocerySellers)
            {
                if(seller.GroceryItemType == groceryItem.GroceryItemType) sellersToActivate.Add(seller);
                else sellersToDeactivate.Add(seller);
            }
        }

        foreach(GrocerySellerController seller in sellersToActivate) seller.ActivateGrocerySeller();
        foreach(GrocerySellerController seller in sellersToDeactivate) seller.DeActivateGrocerySeller();


    }
}