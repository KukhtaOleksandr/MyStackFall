using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public UnityEvent<bool> UIWasClicked;
    public void OnPointerDown(PointerEventData eventData)
    {
        UIWasClicked?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UIWasClicked?.Invoke(false);
    }
    
}
