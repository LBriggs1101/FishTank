using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopCode : MonoBehaviour
{
    [SerializeField] GameObject shopMenu;
    [SerializeField] GameObject smallShop;
    [SerializeField] GameObject midShop;
    [SerializeField] GameObject bigShop;
    [SerializeField] GameObject deepShop;
    [SerializeField] GameObject oddShop;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject customFish;
    [SerializeField] GameObject customBG;


    public void ShopOpen()
    {
        shopMenu.SetActive(true);
        smallShop.SetActive(true);
        shopButton.SetActive(false);
    }

    public void ShopClose()
    {
        shopMenu.SetActive(false);
        smallShop.SetActive(false);

        midShop.SetActive(false);
        bigShop.SetActive(false);
        deepShop.SetActive(false);
        oddShop.SetActive(false);
        customFish.SetActive(false);
        customBG.SetActive(false);

        shopButton.SetActive(true);
    }

    public void SmallFish()
    {
        smallShop.SetActive(true);
        midShop.SetActive(false);
        bigShop.SetActive(false);
        deepShop.SetActive(false);
        oddShop.SetActive(false);
        customFish.SetActive(false);
        customBG.SetActive(false);
    }

    public void MidFish()
    {
        smallShop.SetActive(false);
        midShop.SetActive(true);
        bigShop.SetActive(false);
        deepShop.SetActive(false);
        oddShop.SetActive(false);
        customFish.SetActive(false);
        customBG.SetActive(false);
    }

    public void BigFish()
    {
        smallShop.SetActive(false);
        midShop.SetActive(false);
        bigShop.SetActive(true);
        deepShop.SetActive(false);
        oddShop.SetActive(false);
        customFish.SetActive(false);
        customBG.SetActive(false);
    }

    public void DeepFish()
    {
        smallShop.SetActive(false);
        midShop.SetActive(false);
        bigShop.SetActive(false);
        deepShop.SetActive(true);
        oddShop.SetActive(false);
        customFish.SetActive(false);
        customBG.SetActive(false);
    }

    public void OddFish()
    {
        smallShop.SetActive(false);
        midShop.SetActive(false);
        bigShop.SetActive(false);
        deepShop.SetActive(false);
        oddShop.SetActive(true);
        customFish.SetActive(false);
        customBG.SetActive(false);
    }

    public void CustomFish()
    {
        smallShop.SetActive(false);
        midShop.SetActive(false);
        bigShop.SetActive(false);
        deepShop.SetActive(false);
        oddShop.SetActive(false);
        customFish.SetActive(true);
        customBG.SetActive(false);
    }

    public void CustomBG()
    {
        smallShop.SetActive(false);
        midShop.SetActive(false);
        bigShop.SetActive(false);
        deepShop.SetActive(false);
        oddShop.SetActive(false);
        customFish.SetActive(false);
        customBG.SetActive(true);
    }

}
