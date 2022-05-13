using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyColor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material material;

    void Update()
    {
        material.color = fcp.color;
    }
}
