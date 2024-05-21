using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandInfo : MonoBehaviour
{
    [SerializeField] GameObject fishInfo;

    public void fishPage()
    {
        fishInfo.SetActive(true);
    }

    public void closePage()
    {
        fishInfo.SetActive(false);
    }

}
