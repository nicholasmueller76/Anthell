using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] TMP_Text CashCounter;
    [SerializeField] int CashAmount;

    [SerializeField] int[] resources = new int[4];

    [SerializeField] TMP_Text DirtCounter;

    [SerializeField] TMP_Text StoneCounter;

    [SerializeField] TMP_Text WoodCounter;

    [SerializeField] TMP_Text SulfurCounter;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize resource amount
        CashAmount = 0;
        //CashCounter.text = CashAmount.ToString();

        resources[0] = 0;
        DirtCounter.text = resources[0].ToString();

        resources[1] = 0;
        StoneCounter.text = resources[1].ToString();

        resources[2] = 0;
        WoodCounter.text = resources[2].ToString();

        resources[3] = 0;
        SulfurCounter.text = resources[3].ToString();
    }

    // Adds or subtracts from a resource's amount
    public void AddResource(TileEntity.TileTypes resource, int amount)
    {
        resources[(int)resource] += amount;

        switch (resource)
        {
        case TileEntity.TileTypes.Dirt:
            DirtCounter.text = resources[0].ToString();
            break;
        case TileEntity.TileTypes.Stone:
            StoneCounter.text = resources[1].ToString();
            break;
        case TileEntity.TileTypes.Wood:
            WoodCounter.text = resources[2].ToString();
            break;
        case TileEntity.TileTypes.Sulfur:
            SulfurCounter.text = resources[3].ToString();
            break;
        default:
            print ("Invalid Resource.");
            break;
        }
    }

    public void RemoveResources(TileEntity.TileTypes resource, int amount)
    {
        resources[(int)resource] -= amount;
        switch (resource)
        {
        case TileEntity.TileTypes.Dirt:
            DirtCounter.text = resources[0].ToString();
            break;
        case TileEntity.TileTypes.Stone:
            StoneCounter.text = resources[1].ToString();
            break;
        case TileEntity.TileTypes.Wood:
            WoodCounter.text = resources[2].ToString();
            break;
        case TileEntity.TileTypes.Sulfur:
            SulfurCounter.text = resources[3].ToString();
            break;
        default:
            print ("Invalid Resource.");
            break;
        }
    }

    public int GetResource(TileEntity.TileTypes resource)
    {
        if (resource != TileEntity.TileTypes.Empty) return resources[(int)resource];
        else return (int) TileEntity.TileTypes.Empty;
    }

    public void AddCash(int amount)
    {
        CashAmount += amount;
        CashCounter.text = CashAmount.ToString();
        FindObjectOfType<AudioManager>().PlaySFX("Coins");
    }

    public int GetCash()
    {
        return CashAmount;
    }
}
