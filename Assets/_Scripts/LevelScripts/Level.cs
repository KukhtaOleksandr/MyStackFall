using UnityEngine;
using UnityEngine.Events;
public class Level : MonoBehaviour
{
    public UnityEvent GoToNextLevel;
    public int CurrentLevel{get;set;}
    
    private void Start() {
        CurrentLevel=1;
        CurrentLevel=PlayerPrefs.GetInt("Level",1);
        Debug.Log(CurrentLevel);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
        CurrentLevel=PlayerPrefs.GetInt("Level",1);
        GoToNextLevel?.Invoke();
    }
}
