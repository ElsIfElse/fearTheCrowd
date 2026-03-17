using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Singleton
    public static CameraManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    public PlayerCameraHandler PlayerCameraHandler;
    public PlayerCameraHandlerData PlayerCameraHandlerData;

    public void InitializeManager()
    {
        CreateSubhandlers();
        InitializeSubhandlers();
    }

    void CreateSubhandlers()
    {
        PlayerCameraHandler = new();
    }

    void InitializeSubhandlers()
    {
        PlayerCameraHandler.Initialize(PlayerCameraHandlerData);
    }
}