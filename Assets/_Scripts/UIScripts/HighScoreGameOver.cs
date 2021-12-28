using UnityEngine;
using UnityEngine.UI;

public class HighScoreGameOver : MonoBehaviour
{
    private void Start() 
    {
        Text hishscoreText=GetComponent<Text>();
        if(hishscoreText.text=="")
        {
            hishscoreText.text="HIGHSCORE:"+PlayerPrefs.GetInt("HighScore", 0);
        }
        else
        {
            hishscoreText.text=hishscoreText.text+PlayerPrefs.GetInt("HighScore", 0);
        }
        
    }
}
