using UnityEngine;

public class GrocerySellerController : MonoBehaviour
{
    public GroceryItemType GroceryItemType;
    public bool _isActive;
    public float _detectionRadius;
    public  bool _isPlayerInDetectionRange = false;

    void Start()
    {
        GrocerySellerManager.Instance.RegisterGrocerySeller(this);
        // ActivateGrocerySeller();
    }

    void OnDestroy()
    {
        GrocerySellerManager.Instance.UnRegisterGrocerySeller(this);
    }

    public void ActivateGrocerySeller()
    {
        Debug.Log($"Activate GrocerySeller: [{GroceryItemType}]");
        _isActive = true;
        gameObject.transform.localScale = Vector3.one * 3;
    }
    public void DeActivateGrocerySeller()
    {
        Debug.Log($"Deactivate GrocerySeller: [{GroceryItemType}]");
        gameObject.transform.localScale = Vector3.one;
        _isActive = false;
    }

    void Update()
    {
        if(_isPlayerInDetectionRange && _isActive)
        {
            if(InputManager.Instance.IsInteractionWithSellerPressed()) OnComplete();
        }
    }

    void OnComplete()
    {
        DeActivateGrocerySeller();
        GroceryItemManager.Instance.MoveItemFromTaskListToPlayerInventory(GroceryItemType);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerInDetectionRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerInDetectionRange = false;
        }
    }
}