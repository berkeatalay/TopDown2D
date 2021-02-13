using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] RectTransform dragTransform;
    [SerializeField] Canvas canvas;


    private void Awake()
    {

        if (dragTransform == null)
        {
            dragTransform = transform.GetComponent<RectTransform>();
        }

        if (canvas == null)
        {
            Transform testCancasTransform = transform.parent;
            while (testCancasTransform != null)
            {
                canvas = testCancasTransform.GetComponent<Canvas>();
                if (canvas != null)
                {
                    break;
                }
                testCancasTransform = testCancasTransform.parent;
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        dragTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        dragTransform.SetAsLastSibling();
    }
}
