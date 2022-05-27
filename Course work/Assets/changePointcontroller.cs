using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;

public class changePointcontroller : MonoBehaviour, IPointerDownHandler

{
    public LineRenderer lineRenderer;
    public GameObject line;
    public GameObject panel;
    public CoordinatePanelController coordinatePanelController;
    public GameObject drawButton;
    private drawButtonController _drawButtonController;
    public int pointCount;
    private List<string> _names = new List<string>() {"Sphere", "Sphere(Clone)", "tr  gizmo v2", "tr  gizmo v2 (1)", "tr  gizmo v2 (2)", "transform gizmos" };
    
    public void OnPointerDown(PointerEventData eventData) {
    
        if ((eventData.button == PointerEventData.InputButton.Left) && (!_drawButtonController.GetDrawingStatus()))
        {
            coordinatePanelController.ChangeCoordinats(eventData.pointerCurrentRaycast.gameObject.transform.position);
            coordinatePanelController.cpc = this.gameObject.GetComponent<changePointcontroller>();
            coordinatePanelController.changePoint = this.gameObject;
            panel.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            if (eventData.lastPress != null)
            {
                if (_names.Contains(eventData.lastPress.name))
                {
                    if (((eventData.pointerCurrentRaycast.gameObject != eventData.lastPress.gameObject) && (eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).gameObject != eventData.lastPress.gameObject)) || !eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                        if (eventData.lastPress.name != "transform gizmos")
                            eventData.lastPress.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        else
                            eventData.lastPress.gameObject.SetActive(false);
                }
            }
        }
    }

    void Start()
    {
        _drawButtonController = drawButton.GetComponent<drawButtonController>();
        transform.GetChild(0).gameObject.SetActive(false);
        lineRenderer = line.GetComponent<lineController>().GetComponent<LineRenderer>();
        coordinatePanelController = panel.GetComponent<CoordinatePanelController>();
        // pointCount = lineRenderer.positionCount-1;
    }

    void Update()
    {   
        if (transform.GetChild(0).gameObject.activeInHierarchy && Input.GetMouseButtonDown(0) && (!EventSystem.current.IsPointerOverGameObject()))
        {
            panel.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
