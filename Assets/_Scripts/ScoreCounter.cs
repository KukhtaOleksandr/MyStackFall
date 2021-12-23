using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public UnityEvent ChangedScore;
    [SerializeField] public int Score { get; set; }
    private void Awake()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
    }

    public void OnTileDestroyed()
    {
        AddScore(1);
    }
    public void OnInvincibleTileDestroyed()
    {
        AddScore(2);
    }
    public void OnPlayerLose()
    {
        PlayerPrefs.SetInt("Score", 0);
        Score = PlayerPrefs.GetInt("Score");
        ChangedScore?.Invoke();
    }
    private void AddScore(int scoreAddition)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreAddition);
        Score = PlayerPrefs.GetInt("Score");

        ChangedScore?.Invoke();

        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }

    }
}
