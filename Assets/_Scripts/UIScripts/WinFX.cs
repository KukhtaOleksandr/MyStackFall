using UnityEngine;

public class WinFX : MonoBehaviour
{
    [SerializeField]GameObject winFx;
    public void OnPlayerWin()
    {
        winFx.SetActive(true);
    }
}
