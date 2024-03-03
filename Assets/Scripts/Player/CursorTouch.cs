
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool touching = false;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        touching = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        touching = false;
        
    }
}
