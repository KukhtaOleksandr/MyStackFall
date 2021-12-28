using UnityEngine;

public class PlayerTrailColor : MonoBehaviour
{
    [SerializeField] Material playerMaterial;
    private void Start() {
        GetComponent<TrailRenderer>().material.color=playerMaterial.color;
    }
}
