using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerMovementHandler : ITickable
{
    private float _movementSpeed;
    private float _rotationSpeed;
    private CharacterController _controller;
    private CinemachineCamera _playerCamera;

    public void Initialize(PlayerMovementHandlerData data)
    {
        _movementSpeed = data.MovementSpeed;
        _rotationSpeed = data.RotationSpeed;
        _controller = data.Controller;
        _playerCamera = data.PlayerCamera;

        TickManager.Instance.RegisterTickable(this);
    }
    void MoveCharacter()
    {
        Vector2 movementInput = InputManager.Instance.PlayerMovement;
        float speedOnY = movementInput.y > 0 ? _movementSpeed : _movementSpeed/2;
        Vector3 localDirection = new Vector3(movementInput.x, 0 , movementInput.y).normalized;
        localDirection = new Vector3(localDirection.x * _movementSpeed,0,localDirection.z * speedOnY);
        Vector3 worldDirection = _controller.transform.TransformDirection(localDirection);
        _controller.SimpleMove(worldDirection);
    }

    void HandleRotation()
    {
        _controller.transform.rotation = Quaternion.Euler(0, _playerCamera.transform.rotation.eulerAngles.y, 0);
    }
    public void Tick()
    {
        MoveCharacter(); 
        HandleRotation();
    }

}

[Serializable]
public struct PlayerMovementHandlerData
{
    public float MovementSpeed;
    public float RotationSpeed;
    public CharacterController Controller;  
    public CinemachineCamera PlayerCamera;  
}