using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Player),typeof(PlayerInput),typeof(PlayerInvincibility))]
public class PlayerAttack : MonoBehaviour
{
    public UnityEvent TileDestroyed;
    public UnityEvent InvincibleTileDestroyed;
    public UnityEvent PlayerLose;
    public UnityEvent PlayerWin;
    private Player player;
    private PlayerInput playerInput;
    private PlayerInvincibility playerInvincibility;
    private void Awake()
    {
        player=GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        playerInvincibility = GetComponent<PlayerInvincibility>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (playerInvincibility.IsInvincible)
        {
            if (other.gameObject.tag == "enemy" || other.gameObject.tag == "plane")
            {
                InvincibleTileDestroyed?.Invoke();
                other.transform.parent.GetComponent<StackController>().ShatterAllParts();
            }
        }
        if (playerInput.IsHoldingTouch)
        {
            if (other.gameObject.tag == "enemy")
            {
                TileDestroyed?.Invoke();
                other.transform.parent.GetComponent<StackController>().ShatterAllParts();
            }
            if (other.gameObject.tag == "plane")
            {
                PlayerLose?.Invoke();
                Debug.Log("Gameover");
            }
        }
        if (other.gameObject.tag=="Finish" && player.PlayerState==Player.playerState.Playing)
        {
            PlayerWin?.Invoke();
            player.PlayerState=Player.playerState.Finished;
        }
    }
}
