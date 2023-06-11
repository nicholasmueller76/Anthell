using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Pathfinding;

public class TilemapManager : MonoBehaviour
{
    public Color[] tileColors = new Color[4];

    public Tilemap map;

    public TileBase[,] tiles;
    public GameObject[,] tileEntities;

    public TileBase[] tileFiles = new TileBase[4];

    // Start is called before the first frame update
    void Start()
    {
        map.CompressBounds();
        BoundsInt bounds = map.cellBounds;
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
                // Offset by 1 in the z axis so that the tile entites are behind any object on the map
                newTileData.transform.localPosition = new Vector3(x, y, 0);
                newTileData.name = "TileData: " + x + ", " + y;

                tileEntities[x, y] = newTileData;
                tiles[x, y] = tile;

                newTileData.AddComponent<TileEntity>().ConstructTileEntity(tiles[x, y], tileFiles);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void SetTileObject(Vector3 globalPos, TileBase tile, TileEntity.TileTypes type)
    {
        map.SetTile(map.WorldToCell(globalPos), tile);
        map.SetColor(map.WorldToCell(globalPos), tileColors[(int)type]);
        map.gameObject.GetComponent<TilemapCollider2D>().ProcessTilemapChanges();
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }

    public GameObject getTileObject(int x, int y)
    {
        if (x < tileEntities.GetLength(0) && y < tileEntities.GetLength(1)) return tileEntities[x, y];
        else return null;
    }
}
