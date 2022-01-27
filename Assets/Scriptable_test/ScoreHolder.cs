using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHolder : MonoBehaviour
{
    public Text GemsText;
    public Text DiamondText;

    public CoinsAvailable Gems;
    public CoinsAvailable Diamonds;

    private void Start()
    {
        GemsText.text = Gems.AvailableCount.ToString();
        DiamondText.text = Diamonds.AvailableCount.ToString();
    }

    public void Increase()
    {
        Diamonds.AvailableCount += 10;
        Gems.AvailableCount += 5;

        GemsText.text = Gems.AvailableCount.ToString();
        DiamondText.text = Diamonds.AvailableCount.ToString();
    }

}
