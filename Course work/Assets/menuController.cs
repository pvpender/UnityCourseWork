using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using SFB;

[Serializable]
class SaveData
{
    private Vector3[] _coordinates;

    public void saveCoordinates(Vector3[] coordinates)
    {
        _coordinates = coordinates;
    }
}

public class menuController : MonoBehaviour
{ 
    private LineRenderer lineRenderer;
    public GameObject line;

    private void Start()
    {
        lineRenderer = line.GetComponent<lineController>().GetLineRenderer();
    }
    public void newProject()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("changePoint");
        foreach (GameObject i in gameObjects)
        {
            if (i.name != "Sphere")
            {
                Destroy(i);
            }
            else
            {
                i.transform.position = Vector3.zero;
            }
        }
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, Vector3.zero);
    }

    public void save()
    {
        SaveData saveData = new SaveData();
        Vector3[] mas = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(mas);
        saveData.saveCoordinates(mas);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void export()
    {
        var path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", "txt");
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
