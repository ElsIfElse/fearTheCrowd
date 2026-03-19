using System.Collections.Generic;
using UnityEngine;

public class GroceryItemManager : MonoBehaviour
{
    #region Singleton
    public static GroceryItemManager Instance;
    void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    GroceryTaskController _groceryTaskController; 
    GroceryCollection _groceryCollection;

    public GroceryItemFactory GroceryItemFactory;

    [Header("Initialization Data")]
    public GroceryItemFactoryData GroceryItemFactoryData;
    public GroceryTaskControllerData GroceryTaskControllerData;
    public GroceryCollectionData GroceryCollectionData;

    void Start()
    {
        InitializeManager();
    }

    public void InitializeManager()
    {
        CreateSubHandlers();
        InitializeSubhandlers();
    }

    public void CreateNewGroceryTaskList(int amountOfTasks)
    {
        List<GroceryTaskItem> groceryTaskItems = new();
        for(int i = 0; i < amountOfTasks; i++)
        {
            GroceryItem item = _groceryCollection.GetRandomGroceryItem();
            GroceryTaskItem taskItem = GroceryItemFactory.GetNewGroceryTaskItem(item.GroceryItemType).GetComponent<GroceryTaskItem>(); 
            _groceryTaskController.AddItemToTasks(taskItem);
            groceryTaskItems.Add(taskItem);
        }

        GrocerySellerManager.Instance.ActivateSellers(groceryTaskItems);
    }
    public void MoveItemFromTaskListToPlayerInventory(GroceryItemType type)
    {
        GroceryTaskItem item = _groceryTaskController.FindItemByGroceryType(type);
        _groceryTaskController.RemoveItemFromTasks(item);
        PlayerManager.Instance.PlayerGroceryInventoryManager.AddGroceryTaskItemToPlayerInventory(item);
    }

    void CreateSubHandlers()
    {
        _groceryTaskController = new();
        _groceryCollection = new();
    }
    void InitializeSubhandlers()
    {
        _groceryTaskController.InitializeController(GroceryTaskControllerData);
        _groceryCollection.Initialize(GroceryCollectionData);

        GroceryItemFactoryData.GroceryItemList = _groceryCollection;
        GroceryItemFactory.InitializeFactory(GroceryItemFactoryData);
    }
}
