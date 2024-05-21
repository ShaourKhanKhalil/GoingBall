using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour , IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector2 Direction;
    [SerializeField]
    public RectTransform IntialPoint;
    public RectTransform StickedToTouchPoint;
    public RectTransform FollowingPoint;
    private Transform circle;

    void Start()
    {

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

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen coordinates to world coordinates if needed
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Debug.Log("X = "+ worldMousePosition.x);
        Debug.Log("Y = "+ worldMousePosition.y);

        circle.position = worldMousePosition;
        // Check for mouse button down
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            Debug.Log("Mouse button down at: " + worldMousePosition);
            circle.gameObject.SetActive(true);
        }

        // Check for mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse button up at: " + worldMousePosition);
            circle.gameObject.SetActive(false);
        }
        //transform.position = Vector3.Lerp(transform.position, inputPosition, Time.deltaTime * moveSpeed);
    }
}
