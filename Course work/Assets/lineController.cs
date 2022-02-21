using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineController : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void setNewPoint(Vector3 pointPosition)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, pointPosition);
    }

    void Update()
    {


    }
}
