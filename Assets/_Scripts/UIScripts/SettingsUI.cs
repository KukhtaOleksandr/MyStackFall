using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject buttonsGameObject;
    private bool IsUIOpened;
    
    public void ChangeUIView()
    {
        IsUIOpened = !IsUIOpened;
        buttonsGameObject.SetActive(IsUIOpened);
    }
}
