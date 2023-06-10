using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResourceUpdate : MonoBehaviour
{
    public GameObject otherGameObject;

    public void Add()
    {
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(1,1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(2,1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(3,1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(4,1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(5,1);
    }

    public void Subtract()
    {
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(1,-1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(2,-1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(3,-1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(4,-1);
       otherGameObject.GetComponent<ResourceManager>().UpdateAmount(5,-1);
    }

}
