using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{

    [Header("Money and UI")]
    public int playerCoins = 10;

    public PlayerInv invSystem;


    void Start()
    {
        playerCoins = 10;
    }

    void Update()
    {
       playerCoins = invSystem.playerCoins;
        
    }
}
