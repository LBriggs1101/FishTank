using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{

    [Header("Money and UI")]
    public int playerCoins = 10;

    public PlayerInv invSystem;
    public Texture2D coinIcon;
    [SerializeField] public bool hideUI = false;


    void Start()
    {
        playerCoins = 10;
    }

    void Update()
    {
       playerCoins = invSystem.playerCoins;
        
    }

    public void OnGUI()
    {
        if(!hideUI)
        {
            GUI.Label(new Rect(10, 10, 100, 100), coinIcon);
            GUI.Label(new Rect(110, 45, 100, 100), playerCoins.ToString());
        }
        else
        {
            GUI.Label(new Rect(99999, 99999, 99999, 99999), coinIcon);
            GUI.Label(new Rect(99999, 99999, 99999, 99999), playerCoins.ToString());
        }
        
    }

    public void disableUI()
    {
        hideUI = true;
    }

    public void enableUI()
    {
        hideUI = false;
    }
}
