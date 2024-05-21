using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector2 Direction;
    [SerializeField]
    public RectTransform circle;

    public RectTransform IntialPoint;
    public RectTransform StickedToTouchPoint;
    public RectTransform FollowingPoint;

    void Start()
    {
        Vector2 center = new Vector2(0.5f, 0.5f);
        IntialPoint.pivot = center;

        StickedToTouchPoint.anchorMin = center;
        StickedToTouchPoint.anchorMax = center;
        StickedToTouchPoint.pivot = center;
        StickedToTouchPoint.anchoredPosition = Vector2.zero;

        StickedToTouchPoint.anchorMin = center;
        StickedToTouchPoint.anchorMax = center;
        StickedToTouchPoint.pivot = center;
        StickedToTouchPoint.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = touch.position;

            Vector3 worldTouchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            worldTouchPosition.z = 0;



            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Touch began at: " + worldTouchPosition);
                    circle.gameObject.SetActive(true);
                    circle.position = worldTouchPosition;
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Touch ended at: " + worldTouchPosition);
                    circle.gameObject.SetActive(false);
                    break;
            }


            circle.position = worldTouchPosition;
        }
    }
}
