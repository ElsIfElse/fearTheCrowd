using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    InputAction _playerMovement;
    public Vector2 PlayerMovement
    {
        get
        {
            return _playerMovement.ReadValue<Vector2>();
        }
    }
    
    InputAction _interactWithSeller;
    public bool IsInteractionWithSellerPressed()
    {
        return _interactWithSeller.WasPressedThisFrame();
    } 
    void Start()
    {
        InitializeAction_PlayerMovement();
        InitializeAction_InteractWithSeller();
    }

    void InitializeAction_PlayerMovement()
    {
        _playerMovement = new InputAction("PlayerMovement", InputActionType.Value);
        _playerMovement.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d")
            .With("Right", "<Keyboard>/rightArrow");

        _playerMovement.Enable();
    }

    void InitializeAction_InteractWithSeller()
    {
        _interactWithSeller = new InputAction("InteractWithSeller", InputActionType.Button);
        _interactWithSeller.AddBinding("<Keyboard>/e");
        _interactWithSeller.Enable();
    }
}