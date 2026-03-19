using JetBrains.Annotations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager Instance;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    PlayerMovementHandler _playerMovementHandler;
    [SerializeField] PlayerMovementHandlerData _playerMovementHandlerData;

    AnxietyHandler _anxietyHandler;
    [SerializeField] AnxietyHandlerData _anxietyHandlerData;

    public PlayerGroceryInventoryManager PlayerGroceryInventoryManager;
    public PlayerGroceryInventoryManagerData PlayerGroceryInventoryManagerData;


    public void InitializeManager(GameObject playerObj)
    {
        Initialize_PlayerMovementHandler(playerObj);
        Initialize_AnxietyHandler();
        InitializePlayerGroceryInventoryManager();
    }

    void Initialize_PlayerMovementHandler(GameObject playerObj)
    {
        _playerMovementHandler = new();
        _playerMovementHandlerData.Controller = playerObj.GetComponent<CharacterController>();
        _playerMovementHandlerData.PlayerCamera = CameraManager.Instance.PlayerCameraHandlerData.PlayerCamera;
        _playerMovementHandler.Initialize(_playerMovementHandlerData);
    }
    void Initialize_AnxietyHandler()
    {
        _anxietyHandler = new();
        _anxietyHandlerData.AnxietyDetectionData.PlayerObj = _playerMovementHandlerData.Controller.gameObject;
        _anxietyHandler.InitializeHandler(_anxietyHandlerData);
    }

    void InitializePlayerGroceryInventoryManager()
    {
        PlayerGroceryInventoryManager = new();
        PlayerGroceryInventoryManager.InitializeManager(PlayerGroceryInventoryManagerData);
    }

    void OnDrawGizmos()
    {
        if (_anxietyHandlerData.AnxietyDetectionData.PlayerObj == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            _anxietyHandlerData.AnxietyDetectionData.PlayerObj.transform.position,
            _anxietyHandlerData.AnxietyDetectionData.DetectionRadius
        );
    }

    public void BumperDetection(Collider other)
    {
        if(_anxietyHandler.AnxietyDetection.TryBump(other))
        {
            _anxietyHandler.AnxietyModel.AddAnxiety_Amount(_anxietyHandlerData.AnxietyDetectionData.BumpAnxietyGain);
        }
    }

    void OnGUI()
    {
        // GUI.Label(new Rect(0, 50, 100, 30), $"IsBumperOn: [{_anxietyHandler.AnxietyDetection._isBumperActive}]");
    }
}
