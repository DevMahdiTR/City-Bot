using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GamerManager1 : MonoBehaviour
{
    [SerializeField] private int maxCollectIteamToWin;
    [SerializeField] private Text scoreUI;
    [SerializeField] private EnergyMnager energy;
    private int collectedIteam;

    public void UpdateText(int collectedNumber)
    {
        collectedIteam+=collectedNumber;
        scoreUI.text = collectedIteam.ToString();
        if(collectedIteam>=maxCollectIteamToWin)
        {
            energy.canFade = true;
        }
    }


}
