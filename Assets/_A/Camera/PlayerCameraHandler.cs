using System;
using Unity.Cinemachine;

public class PlayerCameraHandler
{
    CinemachineCamera _playerCamera;
    float _cameraRotationSpeed;

    public void Initialize(PlayerCameraHandlerData data)
    {
        _playerCamera = data.PlayerCamera;
    }

    public void SetCameraRotationSpeed(float rotationSpeed)
    {
        
    }
}

[Serializable]
public struct PlayerCameraHandlerData
{
    public CinemachineCamera PlayerCamera;
}