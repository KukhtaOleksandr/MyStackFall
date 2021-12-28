using UnityEngine;

public class LevelColors : MonoBehaviour
{
    [SerializeField]Material playerMaterial;
    [SerializeField] Material levelMaterial;
    [SerializeField] Material poleMaterial;
    private void Start() 
    {
        levelMaterial.color=playerMaterial.color+new Color(-0.1f,-0.1f,-0.1f,0);
        poleMaterial.color=playerMaterial.color+new Color(-0.2f,-0.2f,-0.2f,0);
    }
}
