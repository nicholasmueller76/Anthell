using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TileData", order = 1)]
public class TileData : ScriptableObject
{
    [SerializeField]
    public Tile[] tileFiles = new Tile[4];
}