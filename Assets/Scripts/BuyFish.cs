using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFish : MonoBehaviour
{

    [SerializeField] GameObject fishObject;
    public int fishCost;
    public PlayerInv invSystem;


    public void GetFish()
    {
        if (invSystem.playerCoins >= fishCost)
        {
            Instantiate(fishObject, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-1.0f, 4.5f), 0), Quaternion.identity);
            invSystem.playerCoins = invSystem.playerCoins - fishCost;
        }
    }

}
