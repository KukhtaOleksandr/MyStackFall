using UnityEngine;

public class PlayerSplashFX : MonoBehaviour
{
    [SerializeField] private GameObject SplashFX;
    public void OnCollisionIn(Collision other)
    {
        if (other.transform.tag != "Finish")
        {
            GameObject splash = Instantiate(SplashFX);
            splash.transform.SetParent(other.transform);
            splash.transform.localEulerAngles = new Vector3(90, Random.Range(0, 359), 0);
            float randomScale = Random.Range(0.16f, 0.23f);
            splash.transform.localScale = new Vector3(randomScale, randomScale, 1);
            splash.transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y - 0.28f, transform.position.z);
            splash.GetComponent<SpriteRenderer>().color = transform.GetChild(0).GetComponent<MeshRenderer>().material.color + Color.black;
        }
    }
}
