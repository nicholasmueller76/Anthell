using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TileEntity;

public class ShopMenu : MonoBehaviour
{
    private ResourceManager resourceManager;
    [SerializeField]
    private GameObject workerAnt;
    [SerializeField]
    private GameObject carpenterAnt;
    [SerializeField]
    private GameObject warriorAnt;
    [SerializeField]
    private GameObject bulletAnt;


    public void Awake()
    {
        resourceManager = Camera.main.gameObject.GetComponent<ResourceManager>();
    }

    public void BuyWorker()
    {
        if(resourceManager.GetResource(TileTypes.Dirt) >= 1) 
        {
            Instantiate(workerAnt, new Vector3(4, 2, 0), Quaternion.Euler(0, 0, -90));
            resourceManager.RemoveResources(TileTypes.Dirt, 1);
            Debug.Log("Buy Worker");
        }
    }

    public void BuyCarpenter()
    {
        if(resourceManager.GetResource(TileTypes.Dirt) >= 1) 
        {
            Instantiate(carpenterAnt, new Vector3(4, 2, 0), Quaternion.Euler(0, 0, -90));
            resourceManager.RemoveResources(TileTypes.Dirt, 1);
            Debug.Log("Buy Carpenter");
        }
        
    }

    public void BuyWarrior()
    {
        if(resourceManager.GetResource(TileTypes.Dirt) >= 1) 
        {
            Instantiate(warriorAnt, new Vector3(4, 2, 0), Quaternion.Euler(0, 0, -90));
            resourceManager.RemoveResources(TileTypes.Dirt, 1);
            Debug.Log("Buy Warrior");
        }
    }

    public void BuyBullet()
    {
        if(resourceManager.GetResource(TileTypes.Dirt) >= 1) 
        {
            Instantiate(bulletAnt, new Vector3(4, 2, 0), Quaternion.Euler(0, 0, -90));
            resourceManager.RemoveResources(TileTypes.Dirt, 1);
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
    


}
