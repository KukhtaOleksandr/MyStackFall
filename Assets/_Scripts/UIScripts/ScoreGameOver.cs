using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
    private void Start() 
    {
        Text scoreText=GetComponent<Text>();
        if(scoreText.text=="")
        {
            scoreText.text="SCORE:"+PlayerPrefs.GetInt("Score", 0);
        }
        else
        {
            scoreText.text=scoreText.text+PlayerPrefs.GetInt("Score", 0);
        }
        
    }
}
