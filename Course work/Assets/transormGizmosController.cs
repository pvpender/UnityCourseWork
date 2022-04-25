using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class transormGizmosController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private short flag;
    LineRenderer lineRenderer;
    changePointcontroller cpc;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
        {
            if (eventData.pointerCurrentRaycast.gameObject == transform.GetChild(0).gameObject)
            {
                flag = 1;
            }
            else if (eventData.pointerCurrentRaycast.gameObject == transform.GetChild(1).gameObject)
            {
                flag = 2;
            }
            else if (eventData.pointerCurrentRaycast.gameObject == transform.GetChild(2).gameObject)
            {
                flag = 3;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        flag = 0;
    }

    private void ChangePosition(short a)
    {
        Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        Vector3 pos = transform.parent.position;
        switch (a){
            case 1:
                pos.y += NewPosition.x * Mathf.Sin(Camera.main.transform.eulerAngles.y / 57.7f);
                pos.y += NewPosition.y * Mathf.Cos(Camera.main.transform.eulerAngles.x / 57.7f);
                transform.parent.position = pos;
                break;
            case 2:
                pos.z -= NewPosition.x * Mathf.Sin(Camera.main.transform.eulerAngles.y / 57.7f);
                pos.z += NewPosition.y * Mathf.Cos(Camera.main.transform.eulerAngles.x / 57.7f);
                transform.parent.position = pos;
                break;
            case 3:
                pos.x += NewPosition.x * Mathf.Cos(Camera.main.transform.eulerAngles.y / 57.7f);
                pos.x += NewPosition.y * Mathf.Sin(Camera.main.transform.eulerAngles.x / 57.7f);
                transform.parent.position = pos;
                break;
        }
        lineRenderer.SetPosition(cpc.pointCount, pos);
    }

    void Start()
    {
        cpc = transform.parent.GetComponent<changePointcontroller>();
        lineRenderer = cpc.lineRenderer;
    }
    void Update()
    {
        if (flag > 0)
        {
            ChangePosition(flag);
        }
    }
}
