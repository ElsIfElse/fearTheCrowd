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
        ActivateGrocerySeller();
    }

    void OnDestroy()
    {
        GrocerySellerManager.Instance.UnRegisterGrocerySeller(this);
    }

    public void ActivateGrocerySeller()
    {
        _isActive = true;
    }
    public void DeActivateGrocerySeller()
    {
        _isActive = false;
    }

    void Update()
    {
        if(_isPlayerInDetectionRange && _isActive)
        {
            Debug.Log("IsPlayerInDetectionRange");
            if(InputManager.Instance.IsInteractionWithSellerPressed()) OnComplete();
        }
    }

    void OnComplete()
    {
        DeActivateGrocerySeller();
        GroceryItemManager.Instance.GroceryTaskHandlerModel.DeactivateItem(GroceryItemType);
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