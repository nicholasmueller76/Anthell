using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap tiles;
    [SerializeField] private GameObject tileHighlight;
    private Vector3 mousePosition;
    private Vector3Int mouseTilePosition;

    void Update()
    {
        // Camera movement (Note: Camera speed is set within CameraController)
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            var moveAmount = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            cameraObject.GetComponent<CameraController>().MoveCamera(moveAmount);
        }

        // Camera zoom in/out with scroll.
        if (Input.mouseScrollDelta.y != 0)
        {
            cameraObject.GetComponent<CameraController>().ZoomCamera(-Input.mouseScrollDelta.y);
        }

        // Get the coordinates of the tile that the cursor is currently hovering over.
        // Will show a highlight on the tile that the cursor is on.
        // Left click and do something
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTilePosition = tiles.LocalToCell(mousePosition);
        tileHighlight.transform.position = tiles.GetCellCenterLocal(mouseTilePosition);
        
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Clicked on tile at " + mouseTilePosition);
        }
    }
}
