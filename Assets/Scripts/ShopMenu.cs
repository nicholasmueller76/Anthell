using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TileEntity;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    private EntityData workerAntData;
    [SerializeField]
    private EntityData carpenterAntData;
    [SerializeField]
    private EntityData warriorAntData;
    [SerializeField]
    private EntityData bulletAntData;

    private ResourceManager resourceManager;
    [SerializeField]
    private GameObject workerAnt;
    [SerializeField]
    private GameObject carpenterAnt;
    [SerializeField]
    private GameObject warriorAnt;
    [SerializeField]
    private GameObject bulletAnt;

    [SerializeField] private GameObject queenAnt;

    public void Awake()
    {
        resourceManager = Camera.main.gameObject.GetComponent<ResourceManager>();
    }

    public void BuyWorker()
    {
        if (CanAfford(workerAntData))
        {
            Instantiate(workerAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(workerAntData);
            FindObjectOfType<AudioManager>().PlaySFX("SummonWorker");
            Debug.Log("Buy Worker");
        }
    }

    public void BuyCarpenter()
    {
        if(CanAfford(carpenterAntData)) 
        {
            Instantiate(carpenterAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(carpenterAntData);
            FindObjectOfType<AudioManager>().PlaySFX("SummonCarpenter");
            Debug.Log("Buy Carpenter");
        }
        
    }

    public void BuyWarrior()
    {
        if (CanAfford(warriorAntData))
        {
            Instantiate(warriorAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(warriorAntData);
            FindObjectOfType<AudioManager>().PlaySFX("SummonWarrior");
            Debug.Log("Buy Warrior");
        }
    }

    public void BuyBullet()
    {
        if (CanAfford(bulletAntData))
        {
            Instantiate(bulletAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(bulletAntData);
            FindObjectOfType<AudioManager>().PlaySFX("SummonBullet");
            Debug.Log("Buy Bullet");
        }
    }

    public void BuySpike()
    {
        Debug.Log("Buy Spike");
    }

    public void BuyMine()
    {
        Debug.Log("Buy Mine");
    }
    
    public bool CanAfford(EntityData data)
    {
        if (data.cashCost > resourceManager.GetCash()) return false;
        if (data.dirtCost > resourceManager.GetResource(TileTypes.Dirt)) return false;
        if (data.stoneCost > resourceManager.GetResource(TileTypes.Stone)) return false;
        if (data.woodCost > resourceManager.GetResource(TileTypes.Wood)) return false;
        if (data.sulfurCost > resourceManager.GetResource(TileTypes.Sulfur)) return false;
        return true;
    }

    public void Buy(EntityData data)
    {
        resourceManager.AddCash(-data.cashCost);
        resourceManager.AddResource(TileTypes.Dirt, -data.dirtCost);
        resourceManager.AddResource(TileTypes.Stone, -data.stoneCost);
        resourceManager.AddResource(TileTypes.Wood, -data.woodCost);
        resourceManager.AddResource(TileTypes.Sulfur, -data.sulfurCost);
        FindObjectOfType<AudioManager>().PlaySFX("Coins");
    }
}
