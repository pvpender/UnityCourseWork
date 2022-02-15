using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    private float _sensitivityRotationX = 0.9f;
    private float _sensitivityRotationY = 0.9f;
    private float minimumX = -360f;
    private float maximumX = 360f;
    private float minimumY = -60f;
    private float maximumY = 60f;
    private float rotationY = 0F;
    private float _sensitivityMove = 0.3f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {   
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivityRotationX;
            rotationY += Input.GetAxis("Mouse Y") * _sensitivityRotationY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        if (Input.GetMouseButton(2))
        { 
            Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            Vector3 pos = transform.position;
            pos.x -= NewPosition.x * _sensitivityMove;
            transform.position = pos;

        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = new Vector3(0, 0, 0);
            Plane plane = new Plane(Vector3.up, 0);
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            Camera.main.transform.Rotate(120, 0, 3);
            Debug.Log($"{worldPosition.x} {worldPosition.y} {worldPosition.z}");
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
            Camera cam = Camera.main;
            Camera newCam = Instantiate(Camera.main, new Vector3(0, 0, 0), Quaternion.identity);
            newCam.gameObject.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            newCam.gameObject.transform.Rotate(cam.transform.rotation.x + 180, cam.transform.rotation.y + 180, cam.transform.rotation.z + 180);
            Ray newRay = newCam.ScreenPointToRay(Input.mousePosition);
            Vector3 newPos = newRay.GetPoint(distance);
            Debug.Log($"{newPos.x} {newPos.y} {newPos.z}");
            Destroy(newCam.gameObject);
        }*/
    }
}
