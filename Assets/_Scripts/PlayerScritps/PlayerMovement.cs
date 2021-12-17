using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private int movingDownSpeed = -600, movingUpSpeed = 600, maxUpDistance = 6;
    private Rigidbody rigidBody;
    private bool checkForCollisionExit;
    

    private void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
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
        if (!playerInput.IsHoldingTouch)
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
            if (!playerInput.IsHoldingTouch)
            {
                rigidBody.velocity = new Vector3(0, movingUpSpeed * Time.fixedDeltaTime, 0);
                checkForCollisionExit = false;
            }
        }
    }

    private void StartedTouching()
    {
        if(playerInput.IsHoldingTouch)
        rigidBody.velocity = new Vector3(0, movingDownSpeed * Time.fixedDeltaTime, 0);
    }



}
