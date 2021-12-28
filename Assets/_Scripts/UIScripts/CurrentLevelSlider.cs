using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelSlider : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Text>().text=PlayerPrefs.GetInt("Level",1).ToString();
    }
}
