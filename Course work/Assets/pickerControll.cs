using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickerControll : MonoBehaviour
{
    private bool _active = false;
    public GameObject picker;
    public Button button;

    public void reverseSetActive()
    {
        _active = !_active;
        picker.SetActive(_active);
    }

    void Start()
    {
        picker.SetActive(false);
    }
    void Update()
    {
        /*picker.SetActive(button.IsPressed());*/
    }
}
