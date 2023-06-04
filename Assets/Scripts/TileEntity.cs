using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEntity : MonoBehaviour
{
    [SerializeField]
    TileBase thisTile;

    TileBase[] tileFiles = new TileBase[4];

    public float health;

    private TilemapManager tilemapManager;

    public enum TileTypes
    {
        Dirt,
        PackedDirt,
        Stone,
        Wood
    }

    public TileTypes tileType;

    public GameObject destroyParticleEffect;

    public void ConstructTileEntity(TileBase thisTile, TileBase[] tileFiles)
    {
        this.thisTile = thisTile;
        this.tileFiles = tileFiles;
        health = 100;

        tilemapManager = GetComponentInParent<TilemapManager>();

        for (int i = 0; i < tileFiles.Length; i++)
        {
            if (tileFiles[i] == thisTile)
            {
                tileType = (TileTypes)i;
                break;
            }
        }
    }

    public void PlaceTile(TileTypes type)
    {
        tilemapManager.SetTileObject((int)transform.localPosition.x, (int)transform.localPosition.y, tileFiles[(int)type]);
    }

    public void DestroyTile()
    {
        tilemapManager.SetTileObject((int)transform.localPosition.x, (int)transform.localPosition.y, null);
    }

    public void Dig(float damage)
    {
        health -= damage;
    }
}
