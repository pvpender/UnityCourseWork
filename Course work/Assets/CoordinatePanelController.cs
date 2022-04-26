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
    void Start()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        inputFieldX = transform.GetChild(0).GetComponent<InputField>();
        inputFieldY = transform.GetChild(1).GetComponent<InputField>();
        inputFieldZ = transform.GetChild(2).GetComponent<InputField>();
        this.gameObject.SetActive(false);
    }

    public void ChangeCoordinats(Vector3 coordinates)
    {
        inputFieldX.text = Convert.ToString(coordinates.x);
        inputFieldY.text = Convert.ToString(coordinates.y);
        inputFieldZ.text = Convert.ToString(coordinates.z);
    }

    void Update()
    {
        
    }
}
