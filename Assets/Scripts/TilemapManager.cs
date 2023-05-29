using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap map;

    public TileBase[,] tiles;
    public GameObject[,] tileEntities;

    // Start is called before the first frame update
    void Start()
    {
        map.CompressBounds();
        BoundsInt bounds = map.cellBounds;
        Debug.Log((bounds.xMax - bounds.xMin) + "," + (bounds.yMax - bounds.yMin));
        this.transform.position = new Vector2(bounds.xMin + 0.5f, bounds.yMin + 0.5f);
        tiles = new TileBase[bounds.xMax - bounds.xMin, bounds.yMax - bounds.yMin];
        tileEntities = new GameObject[bounds.xMax - bounds.xMin, bounds.yMax - bounds.yMin];
        TileBase[] allTiles = map.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];

                GameObject newTileData = new GameObject();
                newTileData.transform.parent = this.gameObject.transform;
                newTileData.transform.localPosition = new Vector3(x, y, 0);
                newTileData.name = "TileData: " + x + ", " + y;
                tileEntities[x, y] = newTileData;
                tiles[x, y] = tile;

                /*if (tile != null)
                {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                }
                else
                {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }*/

                newTileData.AddComponent<TileEntity>().ConstructTileEntity(tiles[x, y]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
