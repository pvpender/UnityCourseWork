using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class transormGizmosController : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (EventSystem.current.IsPointerOverGameObject()))
        {
            if (EventSystem.current.currentSelectedGameObject == transform.GetChild(0).gameObject)
            {
                Debug.Log("yea");
            }
        }
    }
}
