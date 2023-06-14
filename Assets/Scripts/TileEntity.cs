using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEntity : MonoBehaviour
{
    TileBase[] tileFiles = new TileBase[4];

    public float health;

    public enum TileTypes
    {
        Empty = -1,
        Dirt,
        Stone,
        Wood,
        Sulfur
    }

    public TileTypes tileType;

    private GameObject digParticleEffect;
    private GameObject destroyParticleEffect;
    private SpriteRenderer diggingSprite;

    public void ConstructTileEntity(TileBase thisTile, TileBase[] tileFiles, Sprite digSprite)
    {
        this.tileFiles = tileFiles;
        health = 100;

        diggingSprite = this.gameObject.AddComponent<SpriteRenderer>();

        diggingSprite.sprite = digSprite;

        diggingSprite.enabled = false;

        diggingSprite.sortingOrder = 5;

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

            digParticleEffect = TilemapManager.instance.tileDigParticles[(int)tileType];
            destroyParticleEffect = TilemapManager.instance.tileDestroyParticles[(int)tileType];
        }
    }

    public void PlaceTile(TileTypes type)
    {
        TilemapManager.instance.SetTileObject(transform.position, tileFiles[(int)type], type);
        tileType = type;
        digParticleEffect = TilemapManager.instance.tileDigParticles[(int)type];
        destroyParticleEffect = TilemapManager.instance.tileDestroyParticles[(int)type];
        health = 100;
    }

    public void DestroyTile()
    {
        TilemapManager.instance.SetTileObject(transform.position, null, TileTypes.Dirt);
        tileType = TileTypes.Empty;
        SetDigQueued(false);
        Instantiate(destroyParticleEffect, this.transform.position, Quaternion.identity);
    }

    public void Dig(float damage)
    {
        health -= damage;
        Instantiate(digParticleEffect, this.transform.position, Quaternion.identity);
    }

    public TileTypes GetTileType()
    {
        return tileType;
    }

    public string GetTileName()
    {
        switch(this.tileType)
        {
            case TileTypes.Dirt:
                return "Dirt";
            case TileTypes.Stone:
                return "Stone";
            case TileTypes.Wood:
                return "Wood";
            case TileTypes.Sulfur:
                return "Sulfur";
            default:
                return "Empty";
        }
    }

    public void SetDigQueued(bool set)
    {
        diggingSprite.enabled = set;
    }
}
