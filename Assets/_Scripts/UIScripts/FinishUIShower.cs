using UnityEngine;

public class FinishUIShower : MonoBehaviour
{
    [SerializeField]GameObject FinishUi;
    public void OnLevelFinished()
    {
        FinishUi.SetActive(true);
    }
}
