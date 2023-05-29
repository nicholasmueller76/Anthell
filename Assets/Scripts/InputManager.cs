using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Anthell;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private Tilemap tiles;
    [SerializeField] private GameObject tileHighlight;

    private TaskAssigner taskAssigner;
    private Vector3 mousePosition;
    private Vector3Int mouseTilePosition;

    private void Awake()
    {
        taskAssigner = new TaskAssigner();
    }

    private void Update()
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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTilePosition = tiles.LocalToCell(mousePosition);
        tileHighlight.transform.position = tiles.GetCellCenterLocal(mouseTilePosition);

        // Left click and do something
        // Will prioritize entities clicked first, then tile
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if any entities have been clicked on. Note that the entities need a collider to be detected!
            RaycastHit2D mouseHit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (mouseHit.collider != null && !mouseHit.collider.gameObject.CompareTag("Tilemap"))
            {
                Debug.Log("Clicked on: " + mouseHit.collider.gameObject.name);
                if (mouseHit.collider.gameObject.CompareTag("Ant"))
                {
                    // If an ant is clicked on, set it as the selected ant
                    taskAssigner.SetNextTaskAnt(mouseHit.collider.gameObject.GetComponent<Ant>());
                }
                else
                {
                    // If anything else is clicked on, set it as the selected target
                    taskAssigner.SetNextTaskTarget(mouseHit.collider.gameObject);
                    taskAssigner.SetNextTaskType(EntityTaskTypes.Move);
                }
            }
            else
            {
                // Else click on the tile highlighted
                Debug.Log("Clicked on tile at " + mouseTilePosition);
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            taskAssigner.AssignNextTask();
        }
    }
}
