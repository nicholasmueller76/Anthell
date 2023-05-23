using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minZoomIn;
    [SerializeField] private float maxZoomOut;

    public void MoveCamera(Vector3 moveAmount)
    {
        transform.Translate(moveAmount * speed * Time.deltaTime);
    }

    public void ZoomCamera(float zoomAmount)
    {
        if (GetComponent<Camera>().orthographicSize + zoomAmount >= minZoomIn && GetComponent<Camera>().orthographicSize + zoomAmount <= maxZoomOut) 
        {
            GetComponent<Camera>().orthographicSize += zoomAmount * zoomSpeed * Time.deltaTime;
        }
    }
}
