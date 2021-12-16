using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Transform winningPlatform;
    private Vector3 cameraPosition;
    private int cameraLowEdge = 5;

    private void Update()
    {
        if (winningPlatform != null)
        {
            if (transform.position.y > player.transform.position.y &&
                transform.position.y > winningPlatform.position.y + cameraLowEdge)
                {
                    cameraPosition=new Vector3(transform.position.x,player.position.y,transform.position.z);
                }
            transform.position=new Vector3(transform.position.x,cameraPosition.y, -5);
        }
    }




    public void OnWinningPlatformCreated(GameObject WinningPlatform)
    {
        winningPlatform = WinningPlatform.transform;

    }
}
