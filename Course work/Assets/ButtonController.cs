using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public GameObject panel;
    private bool _panelStatus = false;
    private bool _panelDiactivated = false;

    public void showPanel()
    {
        PanelController panelController = panel.GetComponent<PanelController>();
        _panelStatus = panelController.getStatus();
        _panelDiactivated = panelController.getDiactivated();
        if (_panelDiactivated)
        {
            panelController.reverseDiacticvated();
        }
        else if (!_panelStatus)
        {
            panel.SetActive(true);
            panelController.reverseStatus();
        }
    }
}
