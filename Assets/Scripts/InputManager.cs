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

    [SerializeField] private TilemapManager tilemapManager;
    private ResourceManager resourceManager;

    //private TaskAssigner taskAssigner;
    private Vector3 mousePosition;
    private Vector3Int mouseTilePosition;
    private GameObject targetObj;

    private Ant selectedAnt;

    private enum ClickTargetTypes {ant, tile, emptyTile, enemy };
    private ClickTargetTypes clickedTarget;

    private bool entityClicked;

    [SerializeField] private TileEntity.TileTypes selectedResource;

    private void Awake()
    {
        //taskAssigner = new TaskAssigner();
        resourceManager = cameraObject.GetComponent<ResourceManager>();
        targetObj = new GameObject();
        targetObj.name = this.gameObject.name + " target";
        selectedResource = TileEntity.TileTypes.Empty;
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

        // Reads the target clicked.
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            RaycastHit2D mouseHit = Physics2D.Raycast(mousePosition, Vector2.zero);

            entityClicked = false;

            if (mouseHit.collider != null)
            {
                if (mouseHit.collider.gameObject.CompareTag("Ant"))
                {
                    clickedTarget = ClickTargetTypes.ant;
                    entityClicked = true;
                }
                else if (mouseHit.collider.gameObject.CompareTag("Enemy"))
                {
                    clickedTarget = ClickTargetTypes.enemy;
                    entityClicked = true;
                }
            }

            //Get tilemap information at the mouse position.
            var tilemapStartingPos = tilemapManager.transform.position;
            int tileIndexX = (int)(mouseTilePosition.x - tilemapStartingPos.x + 0.5f);
            int tileIndexY = (int)(mouseTilePosition.y - tilemapStartingPos.y + 0.5f);
            GameObject tileEntity = tilemapManager.getTileObject(tileIndexX, tileIndexY);

            if (tileEntity != null && !entityClicked)
            {
                if (mouseHit.collider != null && mouseHit.collider.gameObject.CompareTag("Tilemap"))
                {
                    clickedTarget = ClickTargetTypes.tile;
                }
                else
                {
                    clickedTarget = ClickTargetTypes.emptyTile;
                }
            }

            entityClicked = false;

            // Left click selects an ant (make it the selectedAnt), tile (display tile info), or enemy (display enemy info)
            if (Input.GetButtonDown("Fire1"))
            {
                if (clickedTarget == ClickTargetTypes.ant)
                {
                    if (selectedAnt != null) selectedAnt.SetSelected(false);
                    selectedAnt = mouseHit.collider.gameObject.GetComponent<Ant>();
                    selectedAnt.SetSelected(true);
                }
                else if (clickedTarget == ClickTargetTypes.enemy)
                {
                    // Enemy info popup
                }
                else if (clickedTarget == ClickTargetTypes.tile)
                {
                    // Tile info popup
                }
            }
            // If right click, then execute action on the clicked object
            else if (Input.GetButtonDown("Fire2") && selectedAnt != null)
            {
                if (clickedTarget == ClickTargetTypes.enemy)
                {
                    // Attack task
                }
                else if (clickedTarget == ClickTargetTypes.tile)
                {
                    // Dig task
                    selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Move, tileEntity));
                    selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Dig, tileEntity));
                }
                else if (clickedTarget == ClickTargetTypes.emptyTile && selectedResource != TileEntity.TileTypes.Empty && resourceManager.GetResource(selectedResource) > 0)
                {
                    selectedAnt.SetHeldResource(selectedResource);
                    selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Move, tileEntity));
                    selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Build, tileEntity));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedResource = TileEntity.TileTypes.Dirt;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedResource = TileEntity.TileTypes.Stone;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedResource = TileEntity.TileTypes.Wood;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedResource = TileEntity.TileTypes.Sulfur;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (selectedAnt != null) selectedAnt.SetSelected(false);
            selectedAnt = null;
            selectedResource = TileEntity.TileTypes.Empty;
        }
    }
}
