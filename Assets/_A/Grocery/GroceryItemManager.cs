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

    public GroceryItemFactory GroceryItemFactory;

    public GroceryItemListData GroceryItemListData;
    public GroceryItemFactoryData GroceryItemFactoryData;
    public GroceryTaskHandlerModelData GroceryTaskHandlerModelData;
    public GroceryTaskHandlerViewData GroceryTaskHandlerViewData;


    GroceryItemList _groceryItemList;
    public GroceryTaskHandlerModel GroceryTaskHandlerModel;
    GroceryTaskHandlerView _groceryTaskHandlerView;

    void Start()
    {
        InitializeManager();
    }

    void InitializeManager()
    {
        CreateSubHandlers();
        InitializeSubHandlers();
    }

    void CreateSubHandlers()
    {
        _groceryItemList = new();
        GroceryTaskHandlerModel = new();
        _groceryTaskHandlerView = new();
    }

    void InitializeSubHandlers()
    {

        GroceryTaskHandlerModelData.GroceryItemList = _groceryItemList;
        GroceryTaskHandlerModelData.GroceryTaskHandlerView = _groceryTaskHandlerView;

        GroceryTaskHandlerViewData.GroceryItemFactory = GroceryItemFactory;
        GroceryItemFactoryData.GroceryItemList = _groceryItemList;

        GroceryTaskHandlerViewData.GroceryItemFactory = GroceryItemFactory;
        
        _groceryItemList.InitializeGroceryItemList(GroceryItemListData);
        GroceryItemFactory.InitializeFactory(GroceryItemFactoryData);
        GroceryTaskHandlerModel.InitializeHandler(GroceryTaskHandlerModelData);
        _groceryTaskHandlerView.InitializeHandler(GroceryTaskHandlerViewData);
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,30),"Create Item"))
        {
            GroceryTaskHandlerModel.CreateTaskItems(2);
        }
    }
}
