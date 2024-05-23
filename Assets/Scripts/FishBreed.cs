using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBreed : MonoBehaviour
{
    public int fishPop;

    [SerializeField] GameObject fishObject;

    int randomNumber;
    void Update()
    {
        if (fishPop >= 2)
        {

            RandomGen();

            if (randomNumber == 9999)
            {
                MakeBB();
                Debug.Log("A new {fishObject} has been born!");
            }
        }
        
    }

    public void popIncrease()
    {
        fishPop += 1;
    }

    public void RandomGen()
    {
        randomNumber = Random.Range(1, 10000);
        Debug.Log(randomNumber);
    }

    public void MakeBB()
    {
        Instantiate(fishObject, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-1.0f, 4.5f), 0), Quaternion.identity);
        fishPop += 1;
    }
}
    