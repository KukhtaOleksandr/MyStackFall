using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Player), typeof(PlayerInput), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public UnityEvent PlayerJumped;
    public UnityEvent<Collision> InCollision;
    public UnityEvent LevelFinished;
    public UnityEvent PlayerStateEqualsPlaying;
    private Player player;
    private PlayerInput playerInput;
    private int movingDownSpeed = -600, movingUpSpeed = 600, maxUpDistance = 6;
    private int lastStackHashCode;
    private Rigidbody rigidBody;
    private bool checkForCollisionExit, isCollision = true, invokeOnlyOnce = true;
    private bool isUIWasClicked;


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
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, maxUpDistance, rigidBody.velocity.z);
        }
        //if player doesn't hold touch anymore then we start moving ball up
        CheckForCollisionExit();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isCollision)
        {
            isCollision = false;
            if (!playerInput.IsHoldingTouch)
            {
                InCollision?.Invoke(other);
                PlayerJumped?.Invoke();
                rigidBody.velocity = new Vector3(0, movingUpSpeed * Time.fixedDeltaTime, 0);
            }
            else
            {
                checkForCollisionExit = true;
            }
            Invoke("ChangeIsCollision",0.2f);
        }
    }
    private void ChangeIsCollision()
    {
        isCollision=true;
    }
    private void CheckForCollisionExit()
    {
        if (checkForCollisionExit)
        {
            if (!playerInput.IsHoldingTouch || isUIWasClicked)
            {
                rigidBody.velocity = new Vector3(0, movingUpSpeed * Time.fixedDeltaTime, 0);
                checkForCollisionExit = false;
            }
        }
    }

    private void StartedTouching()
    {
        if (!isUIWasClicked)
        {
            if (playerInput.IsHoldingTouch)
            {
                if (player.PlayerState == Player.playerState.Prepare)
                {
                    player.PlayerState = Player.playerState.Playing;
                    PlayerStateEqualsPlaying?.Invoke();
                }
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
    public void OnUIWasClicked(bool IsUIWasClicked)
    {
        isUIWasClicked = IsUIWasClicked;
    }
}
