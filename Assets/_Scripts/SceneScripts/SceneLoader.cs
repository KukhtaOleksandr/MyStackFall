using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene(float delay)
    {
        Invoke("Load",delay);
    }
    private void Load()
    {
        SceneManager.LoadScene(0);
    }
}
