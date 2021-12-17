using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    private PlayerInput playerInput;
    public bool IsInvincible{get;set;}
    private float pressingTime;
    private void Awake() 
    {
        playerInput=GetComponent<PlayerInput>();
    }
    private void FixedUpdate() 
    {
        if(IsInvincible)
        {
            pressingTime-=Time.fixedDeltaTime*.35f;
        }
        else
        {
            if(playerInput.IsHoldingTouch)
            {
                pressingTime +=Time.fixedDeltaTime*.8f;
            }
            else
            {
                pressingTime-=Time.fixedDeltaTime*.5f;
            }
        }

        if(pressingTime>=1)
        {
            pressingTime=1;
            IsInvincible=true;
        }
        else if(pressingTime<=0)
        {
            pressingTime=0;
            IsInvincible=false;
        }
        //print(IsInvincible);
    }
}
