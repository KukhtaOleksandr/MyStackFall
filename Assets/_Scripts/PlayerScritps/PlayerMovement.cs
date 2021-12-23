using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Player), typeof(PlayerInput), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public UnityEvent PlayerJumped;
    public UnityEvent LevelFinished;
    private Player player;
    private PlayerInput playerInput;
    private int movingDownSpeed = -600, movingUpSpeed = 600, maxUpDistance = 6;
    private Rigidbody rigidBody;
    private bool checkForCollisionExit, isCollision = true, invokeOnlyOnce = true;


    private void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
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
        if (isCollision)
        {
            isCollision=false;
            if (!playerInput.IsHoldingTouch)
            {
                PlayerJumped?.Invoke();
                rigidBody.velocity = new Vector3(0, movingUpSpeed * Time.fixedDeltaTime, 0);
            }
            else
            {
                checkForCollisionExit = true;
            }
        }
    }
    private void OnCollisionExit(Collision other) {
        isCollision=true;
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
        if (playerInput.IsHoldingTouch)
        {
            if (player.PlayerState == Player.playerState.Prepare)
                player.PlayerState = Player.playerState.Playing;
            if (player.PlayerState == Player.playerState.Finished)
            {
                if (invokeOnlyOnce == true)
                {
                    LevelFinished?.Invoke();
                    invokeOnlyOnce = false;
                }
            }
            rigidBody.velocity = new Vector3(0, movingDownSpeed * Time.fixedDeltaTime, 0);
        }
    }



}
