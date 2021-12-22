using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    public bool IsHoldingTouch { get; set; }
    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
    }
    private void Start()
    {
        playerInputSystem.Player.Click.started += _ => IsHoldingTouch = true;
        playerInputSystem.Player.Click.canceled += _ => IsHoldingTouch = false;
    }
    private void OnEnable()
    {
        playerInputSystem.Enable();
    }
    private void OnDisable()
    {
        playerInputSystem.Disable();
    }
}
