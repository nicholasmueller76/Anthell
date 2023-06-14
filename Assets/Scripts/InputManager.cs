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

    //private bool isDoubleClick = false;

    private float previousClickTime;
    private float currentClickTime;
    private float clickDelay = 0.5f;

    private Vector2 initialTouchPosition = Vector2.zero;
    private Vector2 initialTouchPosition2 = Vector2.zero;
    private float previousTouchDistance = -1;
    private Vector2 initialRightTouchPosition = Vector2.zero;

    private bool uiClicked = false;

    //private TaskAssigner taskAssigner;
    private Vector3 mousePosition;
    private Vector3Int mouseTilePosition;
    private GameObject targetObj;

    [SerializeField] private Ant selectedAnt;

    private bool menuOpen = true;

    private bool entityHovered = false;

    private enum MouseTargetTypes { none = -1, ant, tile, emptyTile, enemy };
    [SerializeField] private MouseTargetTypes mouseTarget;

    [SerializeField] private TileEntity.TileTypes selectedResource;

    private void Awake()
    {
        //taskAssigner = new TaskAssigner();
        targetObj = new GameObject();
        targetObj.name = this.gameObject.name + " target";
        selectedResource = TileEntity.TileTypes.Empty;
        mouseTarget = MouseTargetTypes.none;

        dirtButton.onClick.AddListener(SwitchToDirt);
        stoneButton.onClick.AddListener(SwitchToStone);
        woodButton.onClick.AddListener(SwitchToWood);
        sulfurButton.onClick.AddListener(SwitchToSulfur);

        previousClickTime = Time.time;
        currentClickTime = Time.time;
    }

    private void Update()
    {
        // Check if clicking on UI to prevent input conflict
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    uiClicked = true;
                }
            }
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            uiClicked = true;
        }
        else
        {
            uiClicked = false;
        }

        MoveCamera();

        if (!uiClicked)
        {
            RaycastHit2D mouseHit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //Get tilemap information at the mouse position.
            var tilemapStartingPos = tilemapManager.transform.position;
            int tileIndexX = (int)(mouseTilePosition.x - tilemapStartingPos.x + 0.5f);
            int tileIndexY = (int)(mouseTilePosition.y - tilemapStartingPos.y + 0.5f);
            GameObject tileEntity = tilemapManager.getTileObject(tileIndexX, tileIndexY);

            if (mouseHit.collider != null)
            {
                if (mouseHit.collider.gameObject.CompareTag("Ant"))
                {
                    TooltipScreenSpaceUI.ShowTooltip_Static("Select " + mouseHit.collider.gameObject.name);
                    mouseTarget = MouseTargetTypes.ant;
                    entityHovered = true;
                }
                else if (mouseHit.collider.gameObject.CompareTag("Enemy"))
                {
                    if(selectedAnt != null) TooltipScreenSpaceUI.ShowTooltip_Static("Attack " + mouseHit.collider.gameObject.name);
                    else TooltipScreenSpaceUI.ShowTooltip_Static(mouseHit.collider.gameObject.name);
                    mouseTarget = MouseTargetTypes.enemy;
                    entityHovered = true;
                }
            }
            else if (tileEntity == null)
            {
                TooltipScreenSpaceUI.HideTooltip_Static();
                mouseTarget = MouseTargetTypes.none;
            }

            if (tileEntity != null && !entityHovered)
            {
                if (mouseHit.collider != null && mouseHit.collider.gameObject.CompareTag("Tilemap"))
                {
                    if (selectedAnt != null) TooltipScreenSpaceUI.ShowTooltip_Static("Dig " + tileEntity.GetComponent<TileEntity>().GetTileType());
                    else TooltipScreenSpaceUI.ShowTooltip_Static(tileEntity.GetComponent<TileEntity>().GetTileType().ToString());
                    mouseTarget = MouseTargetTypes.tile;
                }
                else
                {
                    if (selectedAnt != null && selectedResource != TileEntity.TileTypes.Empty) TooltipScreenSpaceUI.ShowTooltip_Static("Build " + selectedResource);
                    else if(selectedAnt != null && selectedResource == TileEntity.TileTypes.Empty) TooltipScreenSpaceUI.ShowTooltip_Static("Move Here");
                    else TooltipScreenSpaceUI.HideTooltip_Static();
                    mouseTarget = MouseTargetTypes.emptyTile;
                }
            }

            entityHovered = false;


            // Get the coordinates of the tile that the cursor is currently hovering over.
            // Will show a highlight on the tile that the cursor is on.
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseTilePosition = tiles.LocalToCell(mousePosition);
            tileHighlight.transform.position = tiles.GetCellCenterLocal(mouseTilePosition);

            // Reads the target clicked.
            if (Input.GetButtonDown("Fire1"))
            {
                //DetectClickType();

                //Debug.Log(mouseTarget);

                // Left click selects an ant, if an ant is already selected, executes action on tile or enemy clicked.
                if (Input.GetButtonDown("Fire1"))
                {
                    if (mouseTarget == MouseTargetTypes.ant)
                    {
                        Debug.Log(mouseTarget);

                        if (selectedAnt != null) selectedAnt.SetSelected(false);
                        selectedAnt = mouseHit.collider.gameObject.GetComponent<Ant>();
                        selectedAnt.SetSelected(true);
                    }
                    else if (selectedAnt != null)
                    {
                        if (mouseTarget == MouseTargetTypes.enemy)
                        {
                            // Attack task
                            selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Move, mouseHit.collider.gameObject));
                            selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Attack, mouseHit.collider.gameObject));
                        }
                        else if (mouseTarget == MouseTargetTypes.tile)
                        {
                            tileEntity.GetComponent<TileEntity>().SetDigQueued(true);
                            // Dig task
                            selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Move, tileEntity));
                            selectedAnt.AddTask(new EntityTask(EntityTaskTypes.Dig, tileEntity));
                        }
                        else if (mouseTarget == MouseTargetTypes.emptyTile)
                        {
                            if (selectedResource != TileEntity.TileTypes.Empty)
                            {
                                if (ResourceManager.instance.GetResource(selectedResource) > 0)
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

        //Deselect selected ant and selected resource.
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (selectedAnt != null) selectedAnt.SetSelected(false);
            selectedAnt = null;
            selectedResource = TileEntity.TileTypes.Empty;
        }

        // Open/Close Menu
        if (Input.GetKeyDown(KeyCode.E))
        {
            menuOpen = !menuOpen;
        }
        else if (Input.touchCount == 1)
        {
            TouchOpenCloseMenu();
        }

        ToggleMenu();
    }

    private void MoveCamera()
    {
        // Touch controls for camera
        // Move camera in direction that finger is moving from initial touch position
        if (Input.touchCount == 1)
        {
            TouchMoveCamera();
        }
        // Zoom camera by pinching
        else if (Input.touchCount == 2)
        {
            TouchZoomCamera();
        }

        // Mouse + Keyboard controls for camera
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

    // Move camera by touching left side of screen and moving finger in direction to move camera.
    private void TouchMoveCamera()
    {
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                initialTouchPosition = touch.position;
                break;
            case TouchPhase.Moved:
                if (initialTouchPosition.x < Screen.width / 2)
                {
                    Vector2 initialTouchWorldPosition = Camera.main.ScreenToWorldPoint(initialTouchPosition);
                    Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 positionDifference = initialTouchWorldPosition - touchWorldPosition;
                    // If finger moved more than threshold, then move camera
                    if (Vector2.Distance(initialTouchWorldPosition, touchWorldPosition) > 0.3f)
                    {
                        cameraObject.GetComponent<CameraController>().MoveCamera(-positionDifference * 0.75f);
                    }
                }
                break;
            case TouchPhase.Stationary:
                if (initialTouchPosition.x < Screen.width / 2)
                {
                    Vector2 initialTouchWorldPosition = Camera.main.ScreenToWorldPoint(initialTouchPosition);
                    Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 positionDifference = initialTouchWorldPosition - touchWorldPosition;
                    // If finger moved more than threshold, then move camera
                    if (Vector2.Distance(initialTouchWorldPosition, touchWorldPosition) > 0.3f)
                    {
                        cameraObject.GetComponent<CameraController>().MoveCamera(-positionDifference * 0.75f);
                    }
                }
                break;
            default:
                break;
        }
    }

    // Zoom camera by pinching.
    private void TouchZoomCamera()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        // Get initial positions of fingers
        if (touch1.phase == TouchPhase.Began)
        {
            initialTouchPosition = touch1.position;
        }
        if (touch2.phase == TouchPhase.Began)
        {
            initialTouchPosition2 = touch2.position;
        }

        // If distance between fingers not initialized, then set it to distance between initial positions.
        if (previousTouchDistance == -1)
        {
            previousTouchDistance = Vector2.Distance(initialTouchPosition, initialTouchPosition2);
        }

        // When fingers are moving, calculate the new distance between fingers and compare them with previous.
        // Zoom based on that difference.
        if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
        {
            float newDistance = Vector2.Distance(touch1.position, touch2.position);
            float difference = newDistance - previousTouchDistance;
            cameraObject.GetComponent<CameraController>().ZoomCamera(-difference * 0.05f);
            previousTouchDistance = newDistance;
        }

        // When either finger lifted, reset the initial touch distance.
        if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
        {
            previousTouchDistance = -1;
        }
    }

    // Swipe left on right side of the screen to open menu.
    // Swipe right on right side of the screen to close menu.
    private void TouchOpenCloseMenu()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.position.x > Screen.width / 2)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initialRightTouchPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    float touchPositionX = Camera.main.ScreenToWorldPoint(touch.position).x;
                    float initialTouchPositionX = Camera.main.ScreenToWorldPoint(initialRightTouchPosition).x;
                    if (touchPositionX > initialTouchPositionX + 1.0f)
                    {
                        menuOpen = false;
                    }
                    else if (touchPositionX < initialTouchPositionX - 1.0f)
                    {
                        menuOpen = true;
                    }
                    break;
                default:
                    break;
            }
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

    /*
    private void DetectClickType()
    {
        if (Input.touchCount < 2)
        {
            previousClickTime = currentClickTime;
            currentClickTime = Time.time;
            if (currentClickTime - previousClickTime < clickDelay)
            {
                isDoubleClick = true;
            }
            else
            {
                isDoubleClick = false;
            }
        }
    }*/
}