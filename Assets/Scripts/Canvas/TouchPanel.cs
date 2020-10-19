using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private float _horizontal;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _horizontal = eventData.delta.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _horizontal = eventData.delta.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _horizontal = 0f;
    }



    public float GetHorizontal()
    {
        return _horizontal;
    }
}
