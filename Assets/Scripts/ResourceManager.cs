using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] TMP_Text CashCounter;
    [SerializeField] int CashAmount;
    
    [SerializeField] TMP_Text DirtCounter;
    [SerializeField] int DirtAmount;

    [SerializeField] TMP_Text StoneCounter;
    [SerializeField] int StoneAmount;

    [SerializeField] TMP_Text WoodCounter;
    [SerializeField] int WoodAmount;

    [SerializeField] TMP_Text SulfurCounter;
    [SerializeField] int SulfurAmount;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize resource amount
        CashAmount = 0;
        CashCounter.text = CashAmount.ToString();
        
        DirtAmount = 0;
        DirtCounter.text = DirtAmount.ToString();

        StoneAmount = 0;
        StoneCounter.text = StoneAmount.ToString();

        WoodAmount = 0;
        WoodCounter.text = WoodAmount.ToString();

        SulfurAmount = 0;
        SulfurCounter.text = SulfurAmount.ToString();
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
            CashAmount += amount;
            CashCounter.text = CashAmount.ToString();
            break;
        case 2:
            DirtAmount += amount;
            DirtCounter.text = DirtAmount.ToString();
            break;
        case 3:
            StoneAmount += amount;
            StoneCounter.text = StoneAmount.ToString();
            break;
        case 4:
            WoodAmount += amount;
            WoodCounter.text = WoodAmount.ToString();
            break;
        case 5:
            SulfurAmount += amount;
            SulfurCounter.text = SulfurAmount.ToString();
            break;
        default:
            print ("Invalid Resource.");
            break;
        }
    }

}
