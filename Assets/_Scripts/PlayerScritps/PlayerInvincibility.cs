using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerInput))]
public class PlayerInvincibility : MonoBehaviour
{
    private Player player;
    private PlayerInput playerInput;
    private float pressingTime;
    public bool IsInvincible { get; set; }
    private void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void FixedUpdate()
    {
        if (player.PlayerState == Player.playerState.Playing)
        {
            if (IsInvincible)
            {
                pressingTime -= Time.fixedDeltaTime * .35f;
            }
            else
            {
                if (playerInput.IsHoldingTouch)
                {
                    pressingTime += Time.fixedDeltaTime * .8f;
                }
                else
                {
                    pressingTime -= Time.fixedDeltaTime * .5f;
                }
            }

            if (pressingTime >= 1)
            {
                pressingTime = 1;
                IsInvincible = true;
            }
            else if (pressingTime <= 0)
            {
                pressingTime = 0;
                IsInvincible = false;
            }
        }
    }
}
