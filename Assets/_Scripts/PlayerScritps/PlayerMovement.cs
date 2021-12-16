using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private int movingDownSpeed = -600, movingUpSpeed = 600, maxUpDistance = 6;
    private PlayerInput playerInputSystem;
    private Rigidbody rigidBody;
    private bool checkForCollisionExit;
    public bool IsHoldingTouch{get;set;}

    private void Awake()
    {
        playerInputSystem = new PlayerInput();
        rigidBody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        playerInputSystem.Enable();
    }
    private void OnDisable()
    {
        playerInputSystem.Disable();
    }
    private void Start()
    {
        playerInputSystem.Player.Click.performed += _ => IsHoldingTouch = true;
        playerInputSystem.Player.Click.canceled += _ => CancelledTouching();
    }

    private void FixedUpdate()
    {
        StartedTouching();
        //if max up position is reached then we start mowing ball down
        if (rigidBody.velocity.y > maxUpDistance)
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, maxUpDistance, rigidBody.velocity.z);
        //if player doesn't hold touch anymore then we start moving ball up
        CheckForCollisionExit();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!IsHoldingTouch)
        {
            rigidBody.velocity = new Vector3(0, movingUpSpeed * Time.fixedDeltaTime, 0);
        }
        else
        {
            
            checkForCollisionExit = true;
        }
    }
    private void CheckForCollisionExit()
    {
        if (checkForCollisionExit)
        {
            if (!IsHoldingTouch)
            {
                rigidBody.velocity = new Vector3(0, movingUpSpeed * Time.fixedDeltaTime, 0);
                checkForCollisionExit = false;
            }
        }
    }

    private void StartedTouching()
    {
        if(IsHoldingTouch)
        rigidBody.velocity = new Vector3(0, movingDownSpeed * Time.fixedDeltaTime, 0);
    }
    private void CancelledTouching()
    {
        IsHoldingTouch = false;
    }


}
