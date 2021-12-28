using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Player), typeof(PlayerInput), typeof(PlayerInvincibility))]
public class PlayerAttack : MonoBehaviour
{
    public UnityEvent TileDestroyed;
    public UnityEvent InvincibleTileDestroyed;
    public UnityEvent PlayerLose;
    public UnityEvent PlayerWin;
    private Player player;
    private PlayerInput playerInput;
    private PlayerInvincibility playerInvincibility;
    private bool isColission = true, isUIWasClicked;
    private int lastStackHashCode;
    private void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        playerInvincibility = GetComponent<PlayerInvincibility>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isUIWasClicked)
        {
            //метод onCollisionEnter по незрозумілій причині викликається декілька раз
            //хоча повинен викликатись тільки один, тому ми можем запускаєм цей метод тільки
            //тоді коли хешкоди колізій відрізняються
            if (lastStackHashCode != 0)
            {
                if (lastStackHashCode != other.gameObject.GetHashCode())
                {
                    isColission = true;
                }
            }

            //if (isColission)
            //{
                if (playerInput.IsHoldingTouch)
                {
                    //isColission = false;
                    //lastStackHashCode = other.gameObject.GetHashCode();
                    //Якщо гравець invincible він може знищувати любі перешкоди
                    if (playerInvincibility.IsInvincible)
                    {
                        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "plane")
                        {
                            InvincibleTileDestroyed?.Invoke();
                            other.transform.parent.GetComponent<StackController>().ShatterAllParts();
                        }
                    }
                    else if (other.gameObject.tag == "enemy")
                    {
                        TileDestroyed?.Invoke();
                        other.transform.parent.GetComponent<StackController>().ShatterAllParts();
                    }
                    else if (other.gameObject.tag == "plane")
                    {
                        PlayerLose?.Invoke();
                        player.PlayerState=Player.playerState.Died;
                    }
                }
                if (other.gameObject.tag == "Finish" && player.PlayerState == Player.playerState.Playing)
                {
                    PlayerWin?.Invoke();
                    player.PlayerState = Player.playerState.Finished;
                }
            //}
        }
    }
    
    public void OnUIWasClicked(bool IsUIWasClicked)
    {
        isUIWasClicked = IsUIWasClicked;
    }
    
}
