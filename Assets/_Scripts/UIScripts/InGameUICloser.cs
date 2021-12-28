using UnityEngine;

public class InGameUICloser : MonoBehaviour
{
    [SerializeField]GameObject InGameUI;
    public void OnLevelFinished()
    {
        InGameUI.SetActive(false);
    }
}
