using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEntity : MonoBehaviour
{
    [SerializeField]
    TileBase thisTile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConstructTileEntity(TileBase thisTile)
    {
        this.thisTile = thisTile;
    }
}
