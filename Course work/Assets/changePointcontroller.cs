using UnityEngine.EventSystems;
using UnityEngine;

public class changePointcontroller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    private bool test = false;
    private LineRenderer lineRenderer;
    public GameObject line;
    public int pointCount;
    public void OnPointerDown(PointerEventData eventData) { 
        test = true;
        Debug.Log(pointCount);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        test = false;
    }

    void Start()
    {
        lineRenderer = line.GetComponent<lineController>().GetComponent<LineRenderer>();
        pointCount = lineRenderer.positionCount-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            Vector3 pos = transform.position;
            pos.x += NewPosition.x * Mathf.Cos(transform.eulerAngles.y / 57.7f);
            pos.z -= NewPosition.x * Mathf.Sin(transform.eulerAngles.y / 57.7f);
            pos.y += NewPosition.y * Mathf.Cos(transform.eulerAngles.x / 57.7f);
            transform.position = pos;
            lineRenderer.SetPosition(pointCount, transform.position);
        }
    }
}
