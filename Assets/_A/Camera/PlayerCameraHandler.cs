using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class PlayerCameraHandler
{
    CinemachineCamera _playerCamera;
    float _cameraRotationSpeed;

    public void Initialize(PlayerCameraHandlerData data)
    {
        _playerCamera = data.PlayerCamera;
    }

    public void SetCameraTarget(GameObject playerObj)
    {
        _playerCamera.Target.TrackingTarget = playerObj.transform;
    }
}

[Serializable]
public struct PlayerCameraHandlerData
{
    public CinemachineCamera PlayerCamera;
}