using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerColor : MonoBehaviour
{
    public UnityEvent<int> PlayerColorSet;
    [SerializeField]Material playerMaterial;
    [SerializeField]Color[] colors=new Color[7];
    private void Awake() 
    {   
        int colorId=Random.Range(0,6);
        //int colorId=0;
        playerMaterial.color=colors[colorId];
        PlayerColorSet?.Invoke(colorId);
    }

}
