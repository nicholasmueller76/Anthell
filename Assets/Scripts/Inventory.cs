using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] TMP_Text Resource1Text;
    [SerializeField] int Resource1Amount;
    
    [SerializeField] TMP_Text Resource2Text;
    [SerializeField] int Resource2Amount;

    [SerializeField] TMP_Text Resource3Text;
    [SerializeField] int Resource3Amount;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize Resource values
        Resource1Amount = 0;
        Resource1Text.text = "<sprite=12>:" + Resource1Amount;
        
        Resource2Amount = 0;
        Resource2Text.text = "<sprite=12>:" + Resource1Amount;
        
        Resource3Amount = 0;
        Resource3Text.text = "<sprite=12>:" + Resource1Amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Adds or subtracts from a resource's amount
    public void UpdateAmount(int x, int amount)
    {
        
        switch (x)
        {
        case 1:
            Resource1Amount += amount;
            Resource1Text.text = "<sprite=12>:" + Resource1Amount;
            break;
        case 2:
            Resource2Amount += amount;
            Resource2Text.text = "<sprite=12>:" + Resource2Amount;
            break;
        case 3:
            Resource3Amount += amount;
            Resource3Text.text = "<sprite=12>:" + Resource3Amount;
            break;
        default:
            print ("Invalid Resource.");
            break;
        }
    }
}
