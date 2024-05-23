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
        if(fishPop >= 2)
        {
            randomNumber = Random.Range(1, 250);
            Debug.Log(randomNumber);

            if (randomNumber == 249)
            {
                Instantiate(fishObject, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-1.0f, 4.5f), 0), Quaternion.identity);
                fishPop += 1;
            }
        }
        
    }
}
