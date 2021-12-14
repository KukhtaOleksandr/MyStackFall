using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInputSystem;
    private bool isHoldingTouch;
    private void Awake() 
    {
        playerInputSystem = new PlayerInput();
    }
    private void OnEnable() {
        playerInputSystem.Enable();
    }
    private void OnDisable() {
        playerInputSystem.Disable();
    }
    private void Start() {
        playerInputSystem.Player.Click.performed+= _ =>isHoldingTouch = true;
        playerInputSystem.Player.Click.canceled+= _ =>isHoldingTouch=false;
    }



    private void FixedUpdate() 
    {
        if(isHoldingTouch)
            Debug.Log("hold");
        


    }
}
