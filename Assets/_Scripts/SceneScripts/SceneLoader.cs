using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene(float delay)
    {
        Invoke("Load",delay);
    }
    public void LoadThisScene()
    {
        Load();
    }
    private void Load()
    {
        SceneManager.LoadScene(0);
    }
}
