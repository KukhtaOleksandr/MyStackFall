using UnityEngine;
using UnityEngine.UI;

public class LevelSliderFiller : MonoBehaviour
{
    [SerializeField] private GameObject levelSpawner;
    [SerializeField] private GameObject player;
    private LevelSpawner levelSpawnerSc;
    private Image slider;
    private int currentStacksBroken;
    private void Awake()
    {
        levelSpawnerSc=levelSpawner.GetComponent<LevelSpawner>();
        currentStacksBroken=0;
        slider = GetComponent<Image>();
        slider.fillAmount=0;
    }
    public void FillSlider()
    {
        currentStacksBroken++;
        Debug.Log(currentStacksBroken);
        slider.fillAmount=(currentStacksBroken/(float)levelSpawnerSc.TotalStacks);
    }
}
