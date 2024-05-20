using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFish : MonoBehaviour
{

    [SerializeField] GameObject fishObject;

    public void GetFish()
    {
       Instantiate(fishObject, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
