using UnityEngine.EventSystems;
using UnityEngine;

public class changePointcontroller : MonoBehaviour, IPointerDownHandler

{
    public LineRenderer lineRenderer;
    public GameObject line;
    public int pointCount;

    public void OnPointerDown(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        lineRenderer = line.GetComponent<lineController>().GetComponent<LineRenderer>();
        pointCount = lineRenderer.positionCount-1;
        Debug.Log(transform.childCount);
    }

    void Update()
    {   
        if (transform.GetChild(0).gameObject.activeInHierarchy && Input.GetMouseButtonDown(0) && (!EventSystem.current.IsPointerOverGameObject()))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
