using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FinishUILevel : MonoBehaviour
{
    private void Start() {
        GetComponent<Text>().text="Level "+PlayerPrefs.GetInt("Level",1);
    }
}
