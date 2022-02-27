using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawButtonController : MonoBehaviour
{
    private bool _drawingStatus = false;

    public bool GetDrawingStatus()
    {
        return _drawingStatus;
    }

    public void OnClick()
    {
        _drawingStatus = !_drawingStatus;
    }
}
