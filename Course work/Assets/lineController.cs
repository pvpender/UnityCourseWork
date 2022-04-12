using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineController : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    private drawButtonController drawButtonController;
    public GameObject drawButton;
    public GameObject changePoint;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        drawButtonController = drawButton.GetComponent<drawButtonController>();
    }

    public LineRenderer GetLineRenderer()
    {
        return lineRenderer;
    }

    public void setNewPoint(Vector3 pointPosition)
    {
        if (drawButtonController.GetDrawingStatus())
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount-1, pointPosition);
            Instantiate(changePoint, pointPosition, Quaternion.Euler(0, 0, 0));
        }
    }

    void Update()
    {


    }
}
