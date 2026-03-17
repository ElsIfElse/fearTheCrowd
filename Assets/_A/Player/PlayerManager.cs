using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovementHandler _playerMovementHandler;
    [SerializeField] PlayerMovementHandlerData _playerMovementHandlerData;

    AnxietyHandler _anxietyHandler;
    [SerializeField] AnxietyHandlerData _anxietyHandlerData;


    void Start()
    {
        InitializeManager();
    }

    void InitializeManager()
    {
        Initialize_PlayerMovementHandler();
        Initialize_AnxietyHandler();
    }

    void Initialize_PlayerMovementHandler()
    {
        _playerMovementHandler = new();
        _playerMovementHandlerData.PlayerCamera = CameraManager.Instance.PlayerCameraHandlerData.PlayerCamera;
        _playerMovementHandler.Initialize(_playerMovementHandlerData);
    }
    void Initialize_AnxietyHandler()
    {
        _anxietyHandler = new();
        _anxietyHandlerData.AnxietyDetectionData.PlayerObj = _playerMovementHandlerData.Controller.gameObject;
        _anxietyHandler.InitializeHandler(_anxietyHandlerData);
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
}
