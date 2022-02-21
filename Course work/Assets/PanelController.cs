using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private bool _status = false;
    private bool _diactivated = false;
    public GameObject controlButton;
    

    public bool getDiactivated()
    {
        return _diactivated;
    }

    public void reverseDiacticvated()
    {
        _diactivated = !_diactivated;
    }

    public void reverseStatus()
    {
        _status = !_status;
    }
    public bool getStatus()
    {
        return _status;
    }
    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;


    public void sendRaycast(List<RaycastResult> results)
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        m_Raycaster.Raycast(m_PointerEventData, results);
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_status && Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = new List<RaycastResult>();
            sendRaycast(results);
            if ((results.Count > 0) && (results[0].gameObject.name == "Text_file"))
            {
                reverseDiacticvated();
            }
            if((results.Count == 0) || ((results.Count > 0) && (results[0].gameObject.name != "Text")))
            {
                this._status = !_status;
                this.gameObject.SetActive(false);  
            }
                
        }

    }
}
