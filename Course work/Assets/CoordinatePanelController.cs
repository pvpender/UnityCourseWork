using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoordinatePanelController : MonoBehaviour
{
    InputField inputFieldX;
    InputField inputFieldY;
    InputField inputFieldZ;
    public changePointcontroller cpc;
    LineRenderer lineRenderer;
    public GameObject changePoint;
    void Start()
    {
        inputFieldX = transform.GetChild(0).GetComponent<InputField>();
        inputFieldY = transform.GetChild(1).GetComponent<InputField>();
        inputFieldZ = transform.GetChild(2).GetComponent<InputField>();
        inputFieldX.onValueChanged.AddListener(delegate { if (inputFieldX.isFocused) ValueChangeX(); });
        inputFieldY.onValueChanged.AddListener(delegate { if (inputFieldY.isFocused) ValueChangeY(); });
        inputFieldZ.onValueChanged.AddListener(delegate { if (inputFieldZ.isFocused) ValueChangeZ(); });
        inputFieldX.onEndEdit.AddListener(delegate { EmptyCheck(inputFieldX); });
        inputFieldY.onEndEdit.AddListener(delegate { EmptyCheck(inputFieldY); });
        inputFieldZ.onEndEdit.AddListener(delegate { EmptyCheck(inputFieldZ); });
        cpc = changePoint.GetComponent<changePointcontroller>();
        lineRenderer = cpc.line.GetComponent<lineController>().GetComponent<LineRenderer>();
        this.gameObject.SetActive(false);
    }

    public void ChangeCoordinats(Vector3 coordinates)
    {
        inputFieldX.text = Convert.ToString(coordinates.x);
        inputFieldY.text = Convert.ToString(coordinates.y);
        inputFieldZ.text = Convert.ToString(coordinates.z);
    }

    public void ValueChangeX()
    {
        Vector3 coordinates = changePoint.transform.position;
        try
        {
            coordinates.x = Convert.ToSingle(inputFieldX.text);
        }
        catch (FormatException e)
        {
            coordinates.x = 0;
        }
        changePoint.transform.position = coordinates;
        lineRenderer.SetPosition(cpc.pointCount, coordinates);
    }

    public void ValueChangeY()
    {
        Vector3 coordinates = changePoint.transform.position;
        try
        {
            coordinates.y = Convert.ToSingle(inputFieldY.text);
        }
        catch (FormatException e)
        {
            coordinates.y = 0;
        }
        changePoint.transform.position = coordinates;
        lineRenderer.SetPosition(cpc.pointCount, coordinates);
    }

    public void ValueChangeZ()
    {
        Vector3 coordinates = changePoint.transform.position;
        try
        {
            coordinates.z = Convert.ToSingle(inputFieldZ.text);
        }
        catch (FormatException e)
        {
            coordinates.z = 0;
        }
        changePoint.transform.position = coordinates;
        lineRenderer.SetPosition(cpc.pointCount, coordinates);
    }

    public void EmptyCheck(InputField inputField)
    {
        if (inputField.text == "")
        {
            inputField.text = "0";
        }
    }

    void Update()
    {
    }
}
