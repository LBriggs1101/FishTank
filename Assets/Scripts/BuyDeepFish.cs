using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDeepFish : MonoBehaviour
{

    [SerializeField] GameObject fishObject;

    public void GetFish()
    {
       Instantiate(fishObject, new Vector3(0, -3, 0), Quaternion.identity);
    }

}
