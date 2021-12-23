using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
    private Text scoreText;
    private int score;
    private void Awake() {
        scoreText=GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text=score.ToString();
    }
    public void UpdateScoreUI()
    {
        scoreText.text=PlayerPrefs.GetInt("Score", 0).ToString();
    }
}
