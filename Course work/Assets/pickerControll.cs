using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickerControll : MonoBehaviour
{
    private bool _active = false;
    public GameObject picker;

    public void reverseSetActive()
    {
        _active = !_active;
        picker.SetActive(_active);
    }

    void Start()
    {
        picker.SetActive(false);
    }
}
