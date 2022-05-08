using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class drawButtonController : MonoBehaviour
{
    private bool _drawingStatus = false;
    public Color previousColor;
    public bool GetDrawingStatus()
    {
        return _drawingStatus;
    }

    public void OnClick(Button drawButton)
    {
        _drawingStatus = !_drawingStatus;
        if(_drawingStatus)
        {
            previousColor = drawButton.GetComponent<Image>().color;
            drawButton.GetComponent<Image>().color = Color.red;
        } else
        {
            drawButton.GetComponent<Image>().color = previousColor; 
        }
    }
}
