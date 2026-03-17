using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovementHandler _playerMovementHandler;
    [SerializeField] PlayerMovementHandlerData _playerMovementHandlerData;

    void Start()
    {
        _playerMovementHandler = new();
        _playerMovementHandlerData.PlayerCamera = CameraManager.Instance.PlayerCameraHandlerData.PlayerCamera;
        _playerMovementHandler.Initialize(_playerMovementHandlerData);
    }
}
