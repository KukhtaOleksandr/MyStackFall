using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private void Awake()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public void OnTileDestroyed()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        score=PlayerPrefs.GetInt("Score");
        if(PlayerPrefs.GetInt("Score")>PlayerPrefs.GetInt("HighScore",0))
            PlayerPrefs.SetInt("HighScore",score);
    }
    public void OnInvincibleTileDestroyed()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 2);
        score=PlayerPrefs.GetInt("Score");
        if(PlayerPrefs.GetInt("Score")>PlayerPrefs.GetInt("HighScore",0))
            PlayerPrefs.SetInt("HighScore",score);
    }
    public void OnPlayerLose()
    {
        PlayerPrefs.SetInt("Score", 0);
        score=PlayerPrefs.GetInt("Score");
    }
}
