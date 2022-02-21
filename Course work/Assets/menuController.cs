using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class menuController : MonoBehaviour
{
    public void export()
    {

        Debug.Log("da");
        var path = EditorUtility.SaveFilePanel("Save texture as PNG", "", "something.png", "png");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
