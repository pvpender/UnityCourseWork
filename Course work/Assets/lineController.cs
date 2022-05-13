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
            var obj = Instantiate(changePoint, pointPosition, Quaternion.Euler(0, 0, 0));
            obj.GetComponent<changePointcontroller>().pointCount = lineRenderer.positionCount - 1;
        }
    }

    public void undo()
    {
        if (lineRenderer.positionCount > 1)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("changePoint");
            foreach (GameObject i in gameObjects)
            {
                if(i.transform.position == lineRenderer.GetPosition(lineRenderer.positionCount - 1))
                {
                    Destroy(i);
                }
            }
            lineRenderer.positionCount--;
        }
    }

    void Update()
    {


    }
}
