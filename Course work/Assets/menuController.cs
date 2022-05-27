using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using SFB;


[Serializable]
public struct SerializableVector3
{

    public float x;
    public float y;
    public float z;

    public SerializableVector3(float rX, float rY, float rZ)
    {
        x = rX;
        y = rY;
        z = rZ;
    }

    public override string ToString()
    {
        return String.Format("[{0}, {1}, {2}]", x, y, z);
    }

    public static implicit operator Vector3(SerializableVector3 rValue)
    {
        return new Vector3(rValue.x, rValue.y, rValue.z);
    }

    public static implicit operator SerializableVector3(Vector3 rValue)
    {
        return new SerializableVector3(rValue.x, rValue.y, rValue.z);
    }
}

[Serializable]
class SaveData
{
    private List<SerializableVector3> _data = new List<SerializableVector3>();

    public void saveCoordinates(Vector3[] coordinates)
    {
        foreach(Vector3 v in coordinates)
        {
            _data.Add(new SerializableVector3(v.x, v.y, v.z));
        }
    }
    public Vector3[] loadCoordinates()
    {
        Vector3[] coordinates = new Vector3[_data.Count];
        for (int i = 0; i < _data.Count; i++)
        {
            coordinates[i] = (Vector3)_data[i];
        }
        return coordinates;
    }
}

public class menuController : MonoBehaviour
{ 
    private LineRenderer lineRenderer;
    public GameObject line;
    public GameObject changePoint;

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
        var path = StandaloneFileBrowser.SaveFilePanel("Save", "", "MySavingData", "bin");
        SaveData saveData = new SaveData();
        Vector3[] mas = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(mas);
        saveData.saveCoordinates(mas);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void load()
    {
        newProject();
        var path = StandaloneFileBrowser.OpenFilePanel("Load", "", "bin", false);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path[0], FileMode.Open);
        SaveData data = (SaveData)bf.Deserialize(file);
        file.Close();
        Vector3[] mas = data.loadCoordinates();
        for (int i = 1; i < mas.Length; i++)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(i, mas[i]);
            var obj = Instantiate(changePoint, mas[i], Quaternion.Euler(0, 0, 0));
            obj.GetComponent<changePointcontroller>().pointCount = i;
        }
    }
    public void export()
    {
        var path = StandaloneFileBrowser.SaveFilePanel("Export", "", "MySaveFile", "txt");
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
