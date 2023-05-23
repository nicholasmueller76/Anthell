using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;

    public void MoveCamera(Vector3 moveAmount)
    {
        transform.Translate(moveAmount * speed * Time.deltaTime);
    }
}
