using UnityEngine;

public class Player : MonoBehaviour
{
    public enum playerState
    {
        Prepare,
        Playing,
        Died,
        Finished
    }
    [HideInInspector]
    public playerState PlayerState=playerState.Prepare;


}
