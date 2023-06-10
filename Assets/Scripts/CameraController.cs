using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minZoomIn;
    [SerializeField] private float maxZoomOut;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    public void MoveCamera(Vector3 moveAmount)
    {
        transform.Translate(speed * Time.deltaTime * moveAmount);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
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
