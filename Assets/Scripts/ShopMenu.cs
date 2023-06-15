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

    }

    public void BuyWorker()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
        if (CanAfford(workerAntData))
        {
            Instantiate(workerAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(workerAntData);
            Debug.Log("Buy Worker");
            FindObjectOfType<AudioManager>().PlaySFX("Coin");
            FindObjectOfType<AudioManager>().PlaySFX("SummonWorker");
        }
    }

    public void BuyCarpenter()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
        if(CanAfford(carpenterAntData)) 
        {
            Instantiate(carpenterAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(carpenterAntData);
            Debug.Log("Buy Carpenter");
            FindObjectOfType<AudioManager>().PlaySFX("Coin");
            FindObjectOfType<AudioManager>().PlaySFX("SummonCarpenter");
        }
        
    }

    public void BuyWarrior()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
        if (CanAfford(carpenterAntData))
        {
            Instantiate(warriorAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(warriorAntData);
            Debug.Log("Buy Warrior");
            FindObjectOfType<AudioManager>().PlaySFX("Coin");
            FindObjectOfType<AudioManager>().PlaySFX("SummonWarrior");
        }
    }

    public void BuyBullet()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
        if (CanAfford(bulletAntData))
        {
            Instantiate(bulletAnt, queenAnt.transform.position, Quaternion.Euler(0, 0, -90));
            Buy(bulletAntData);
            Debug.Log("Buy Bullet");
            FindObjectOfType<AudioManager>().PlaySFX("Coin");
            FindObjectOfType<AudioManager>().PlaySFX("SummonBullet");
        }
    }

    public void BuySpike()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
        Debug.Log("Buy Spike");
        //FindObjectOfType<AudioManager>().PlaySFX("Coin");
    }

    public void BuyMine()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
        Debug.Log("Buy Mine");
        //FindObjectOfType<AudioManager>().PlaySFX("Coin");
    }
    
    public bool CanAfford(EntityData data)
    {
        if (data.cashCost > ResourceManager.instance.GetCash()) return false;
        if (data.dirtCost > ResourceManager.instance.GetResource(TileTypes.Dirt)) return false;
        if (data.stoneCost > ResourceManager.instance.GetResource(TileTypes.Stone)) return false;
        if (data.woodCost > ResourceManager.instance.GetResource(TileTypes.Wood)) return false;
        if (data.sulfurCost > ResourceManager.instance.GetResource(TileTypes.Sulfur)) return false;
        return true;
    }

    public void Buy(EntityData data)
    {
        ResourceManager.instance.AddCash(-data.cashCost);
        ResourceManager.instance.AddResource(TileTypes.Dirt, -data.dirtCost);
        ResourceManager.instance.AddResource(TileTypes.Stone, -data.stoneCost);
        ResourceManager.instance.AddResource(TileTypes.Wood, -data.woodCost);
        ResourceManager.instance.AddResource(TileTypes.Sulfur, -data.sulfurCost);
    }
}
