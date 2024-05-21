using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{

    [Header("Money and UI")]
    public int playerCoins = 10;

    public PlayerInv invSystem;
    public Texture2D coinIcon;


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
        GUI.Label(new Rect(10, 10, 100, 100), coinIcon);
        GUI.Label(new Rect(110, 45, 100, 100), playerCoins.ToString());
    }
}
