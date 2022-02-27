using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;




public class menuController : MonoBehaviour
{ 
    private LineRenderer lineRenderer;
    public GameObject line;

    private void Start()
    {
        lineRenderer = line.GetComponent<lineController>().GetLineRenderer();
    }
    public void export()
    {
        Debug.Log("da");
        //var path = EditorUtility.SaveFilePanel("Save texture as txt", "", "something.txt", "txt");
        var path = "file.txt";
        StreamWriter streamWriter = new StreamWriter(path);
        Vector3[] mas = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(mas);
        foreach (Vector3 i in mas)
        {
            streamWriter.WriteLine($"{i.x} {i.y} {i.z}");
        }
        streamWriter.Close();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
