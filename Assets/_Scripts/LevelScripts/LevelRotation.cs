using UnityEngine;

public class LevelRotation : MonoBehaviour
{
    private int speed=100;
    private void FixedUpdate() {
        transform.Rotate(new Vector3(0,speed*Time.fixedDeltaTime,0));
    }
}
