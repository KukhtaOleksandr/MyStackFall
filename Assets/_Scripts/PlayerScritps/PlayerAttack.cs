using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInvincibility playerInvincibility;
    private void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
        playerInvincibility=GetComponent<PlayerInvincibility>();
    }
    private void OnCollisionEnter(Collision other) {
        if(playerInvincibility.IsInvincible)
        {
            if(other.gameObject.tag=="enemy"||other.gameObject.tag=="plane")
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
        if(playerInput.IsHoldingTouch)
        {
            if(other.gameObject.tag=="enemy")
            {
                Destroy(other.transform.parent.gameObject);
            }
            if(other.gameObject.tag=="plane")
            {
                Debug.Log("Gameover");
            }
        }
    }
}
