using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinProduction : MonoBehaviour
{
    public int coinProduction = 1;
    [SerializeField] public int coinTime = 5;

    [Header("Inv System")]
    public PlayerInv invSystem;

    void Start()
    {
      StartCoroutine("Produce");
    }

    public IEnumerator Produce()
    {
        yield return new WaitForSeconds(coinTime);
        invSystem.playerCoins = invSystem.playerCoins + coinProduction;
        StartCoroutine("Produce");
    }

}
