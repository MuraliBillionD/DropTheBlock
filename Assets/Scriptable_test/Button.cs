using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{
    public Text Name;

    public Text price;

    public CoinsAvailable coins;
    public Shop HatButton;

    public UnityEngine.UI.Button button;


    private void Start()
    {
        button = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        
        Name.text = HatButton.NameType;
        price.text = HatButton.Count.ToString();
    }


    private void Update()
    {
        if (coins.AvailableCount >= HatButton.Count)
        {

            button.interactable = true;
        }
    }
    public void Buy()
    {
        if (HatButton.Status == false)
        {
            if (coins.AvailableCount >= HatButton.Count)
            {
                HatButton.Status = true;
            }
        }
        else
        {
            price.text = "BOUGHT";
        }
    }


}
