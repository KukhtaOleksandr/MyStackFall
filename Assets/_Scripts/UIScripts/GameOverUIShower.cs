using UnityEngine;

public class GameOverUIShower : MonoBehaviour
{
    [SerializeField]GameObject GameOverUI;
    public void OnPlayerLose()
    {
        GameOverUI.SetActive(true);
    }
}
