using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UISelectHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[HideInInspector] public bool pointerIsDown;
    public UnityEvent onPointerDown;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerIsDown = true;
        onPointerDown.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pointerIsDown = false;
	}
}
