using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Anthell;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private Tilemap tiles;
    [SerializeField] private GameObject tileHighlight;

    [SerializeField] private TilemapManager tilemapManager;
    [SerializeField] private GameObject menuBG;


    [SerializeField] private Button dirtButton;
    [SerializeField] private Button stoneButton;
    [SerializeField] private Button woodButton;
    [SerializeField] private Button sulfurButton;

    private bool isDoubleClick = false;
    private bool checkingClickType = false;
    private float clickTime = 0;
    private float clickDelay = 0.2f;

    private Vector3 initialTouchPosition;

    private ResourceManager resourceManager;

    //private TaskAssigner taskAssigner;
    private Vector3 mousePosition;
    private Vector3Int mouseTilePosition;
    private GameObject targetObj;

    private Ant selectedAnt;

    private bool menuOpen = true;

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

        dirtButton.onClick.AddListener(SwitchToDirt);
        stoneButton.onClick.AddListener(SwitchToStone);
        woodButton.onClick.AddListener(SwitchToWood);
        sulfurButton.onClick.AddListener (SwitchToSulfur);
    }

    private void Update()
    {
        MoveCamera();

        // Get the coordinates of the tile that the cursor is currently hovering over.
        // Will show a highlight on the tile that the cursor is on.
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTilePosition = tiles.LocalToCell(mousePosition);
        tileHighlight.transform.position = tiles.GetCellCenterLocal(mouseTilePosition);

        // Reads the target clicked.
        if(!EventSystem.current.IsPointerOverGameObject() && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            DetectClickType();

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

            Debug.Log(clickedTarget);

            // Left click selects an ant (make it the selectedAnt), tile (display tile info), or enemy (display enemy info)
            if (Input.GetButtonDown("Fire1") && isDoubleClick == false)
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
            else if ((Input.GetButtonDown("Fire2") || isDoubleClick) && selectedAnt != null)
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
                else if (clickedTarget == ClickTargetTypes.emptyTile)
                {
                    if (selectedResource != TileEntity.TileTypes.Empty)
                    {
                        if (resourceManager.GetResource(selectedResource) > 0)
                        {
                            selectedAnt.SetHeldResource(selectedResource);
                            selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Move, tileEntity));
                            selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Build, tileEntity));
                        }
                    }
                    else
                    {
                        selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Move, tileEntity));
                    }
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (menuOpen)
            {
                menuOpen = false;
            }
            else
            {
                menuOpen = true;
            }
        }

        ToggleMenu();

        ClickTimer();
    }

    private void MoveCamera()
    {
        // Based on tutorial from https://kylewbanks.com/blog/unity3d-panning-and-pinch-to-zoom-camera-with-touch-and-mouse-input
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 offset = Camera.main.ScreenToViewportPoint(initialTouchPosition - (Vector3) touch.position);
                Vector3 move = new Vector3(offset.x * 10, offset.y * 10, 0);
                cameraObject.GetComponent<CameraController>().MoveCamera(move);
            }
        }


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
    }

    private void ToggleMenu()
    {
        var menuPosition = menuBG.GetComponent<RectTransform>().anchoredPosition;
        if (menuOpen)
        {
            if (menuPosition.x != 0)
            {
                menuPosition = new Vector3(Mathf.Max(0, menuPosition.x - 50), menuPosition.y);
                menuBG.GetComponent<RectTransform>().anchoredPosition = menuPosition;
            }
        }
        else
        {
            if (menuPosition.x != 525)
            {
                menuPosition = new Vector3(Mathf.Min(525, menuPosition.x + 50), menuPosition.y);
                menuBG.GetComponent<RectTransform>().anchoredPosition = menuPosition;
            }
        }
    }

    private void SwitchToDirt()
    {
        selectedResource = TileEntity.TileTypes.Dirt;
    }

    private void SwitchToStone()
    {
        selectedResource = TileEntity.TileTypes.Stone;
    }

    private void SwitchToWood()
    {
        selectedResource = TileEntity.TileTypes.Wood;
    }

    private void SwitchToSulfur()
    {
        selectedResource = TileEntity.TileTypes.Sulfur;
    }

    private void DetectClickType()
    {
        if (checkingClickType && clickTime < clickDelay)
        {
            checkingClickType = false;
            isDoubleClick = true;
        }
        else
        {
            isDoubleClick = false;
            checkingClickType = true;
            clickTime = 0;
        }
    }

    private void ClickTimer()
    {
        if (checkingClickType)
        {
            clickTime += Time.deltaTime;
        }
    }
}