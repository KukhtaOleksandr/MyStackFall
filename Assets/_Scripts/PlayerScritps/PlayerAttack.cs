using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision other) {
        if(playerMovement.IsHoldingTouch)
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
