using UnityEngine;

public class HomeUICloser : MonoBehaviour
{
    public void OnPlayerStateEqualsPlaying()
    {
        gameObject.SetActive(false);
    }
}
