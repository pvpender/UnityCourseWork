using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameraController : MonoBehaviour
{

    private float _sensitivityRotationX = 1.5f;
    private float _sensitivityRotationY = 1.5f;
    private float _minimumX = -360f;
    private float _maximumX = 360f;
    private float _minimumY = -60f;
    private float _maximumY = 60f;
    private float _rotationY = 0F;
    private float _mouseScrollSensitivity = 1f;
    private float _sensitivityMove = 1f;
    private lineController _lineController;
    private PanelController _panelController;
    public GameObject line;
    public GameObject plane;

    private void Start()
    {
        _lineController = line.GetComponent<lineController>();
        _panelController = plane.GetComponent<PanelController>(); 
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 pos = transform.position;
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                pos = transform.position;
                pos.x += _mouseScrollSensitivity * Mathf.Sin(transform.eulerAngles.y / 57.7f);
                pos.z += _mouseScrollSensitivity * Mathf.Cos(transform.eulerAngles.y / 57.7f);
                pos.y -= _mouseScrollSensitivity * Mathf.Sin(transform.eulerAngles.x / 57.7f);
                transform.position = pos;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                pos = transform.position;
                pos.x -= 1f * Mathf.Sin(transform.eulerAngles.y / 57.7f);
                pos.z -= 1f * Mathf.Cos(transform.eulerAngles.y / 57.7f);
                pos.y += 1f * Mathf.Sin(transform.eulerAngles.x / 57.7f);
                transform.position = pos;
            }
        }
        if (Input.GetMouseButton(1))
        {   
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivityRotationX;
            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityRotationY;
            _rotationY = Mathf.Clamp(_rotationY, _minimumY, _maximumY);
            transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0);
        }
        if (Input.GetMouseButton(2))
        { 
            Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            Vector3 pos = transform.position;
            pos.x -= NewPosition.x * Mathf.Cos(transform.eulerAngles.y / 57.7f) * _sensitivityMove;
            pos.z += NewPosition.x * Mathf.Sin(transform.eulerAngles.y / 57.7f) * _sensitivityMove;
            pos.y -= NewPosition.y * Mathf.Cos(transform.eulerAngles.x / 57.7f) * _sensitivityMove;
            //pos.z -= NewPosition.y * Mathf.Sin(transform.eulerAngles.x / 57.7f) * _sensitivityMove;
            transform.position = pos;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Plane planeX = new Plane(Vector3.up, 0);
            Plane planeY = new Plane(Vector3.forward, 0);
            Plane planeZ = new Plane(Vector3.left, 0);
            Vector3 worldPosition = new Vector3(0, 0, 0);
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                EventSystem.current.SetSelectedGameObject(hit.collider.gameObject);
            }
            if (planeX.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            else if (planeY.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            else if (planeZ.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            List<RaycastResult> results = new List<RaycastResult>();
            _panelController.sendRaycast(results);
            if (results.Count == 0)
            {
                _lineController.setNewPoint(worldPosition);
            }
        }
    }
}
