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
        float newCameraSize = GetComponent<Camera>().orthographicSize + zoomAmount * zoomSpeed * Time.deltaTime;
        if (newCameraSize < minZoomIn)
        {
            newCameraSize = minZoomIn;
        }
        else if (newCameraSize > maxZoomOut)
        {
            newCameraSize = maxZoomOut;
        }
        GetComponent<Camera>().orthographicSize = newCameraSize;
    }
}
