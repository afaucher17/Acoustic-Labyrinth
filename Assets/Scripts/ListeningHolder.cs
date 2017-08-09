using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using System;

public class ListeningHolder : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int doorNumber;

    // Mouse / Touch Down
    public void OnPointerDown(PointerEventData eventData)
    {
        GameplayManager.instance.ListenToDoor(doorNumber);
    }

    // Mouse / Touch Up
    public void OnPointerUp(PointerEventData eventData)
    {
        GameplayManager.instance.StopListening();
    }

    // Mouse Hover Enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameplayManager.instance.ListenToDoor(doorNumber);
    }

    // Mouse Hover Exit
    public void OnPointerExit(PointerEventData eventData)
    {
        GameplayManager.instance.StopListening();
    }
}