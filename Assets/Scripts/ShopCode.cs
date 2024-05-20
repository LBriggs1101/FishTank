using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopCode : MonoBehaviour
{
    [SerializeField] GameObject shopMenu;

    public void ShopOpen()
    {
        shopMenu.SetActive(true);
    }

    public void ShopClose()
    {
        shopMenu.SetActive(false);
    }
}
