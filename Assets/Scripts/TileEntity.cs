using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEntity : MonoBehaviour
{
    TileBase[] tileFiles = new TileBase[4];

    public float health;

    private TilemapManager tilemapManager;

    public enum TileTypes
    {
        Empty = -1,
        Dirt,
        Stone,
        Wood,
        Sulfur
    }

    public TileTypes tileType;

    public GameObject destroyParticleEffect;

    public void ConstructTileEntity(TileBase thisTile, TileBase[] tileFiles)
    {
        this.tileFiles = tileFiles;
        health = 100;

        tilemapManager = GetComponentInParent<TilemapManager>();

        if (thisTile == null)
        {
            tileType = TileTypes.Empty;
        }
        else
        {
            for (int i = 0; i < tileFiles.Length; i++)
            {
                if (tileFiles[i] == thisTile)
                {
                    tileType = (TileTypes)i;
                    break;
                }
            }
        }
    }

    public void PlaceTile(TileTypes type)
    {
        tilemapManager.SetTileObject(transform.position, tileFiles[(int)type], type);
        tileType = type;
        health = 100;
    }

    public void DestroyTile()
    {
        tilemapManager.SetTileObject(transform.position, null, TileTypes.Dirt);
        tileType = TileTypes.Empty;
    }

    public void Dig(float damage)
    {
        health -= damage;
    }

    public TileTypes GetTileType()
    {
        return tileType;
    }
}
