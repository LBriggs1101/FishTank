using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandInfo : MonoBehaviour
{
    [SerializeField] GameObject fishInfo;
    [SerializeField] PageController pageController;
    public int pageVal;

    public void fishPage()
    {

       /* if (pageVal == pageController.curPage)
        { */
            fishInfo.SetActive(true);
            Debug.Log(pageController.curPage);
        /*}
        else
        {
            fishInfo.SetActive(false);
        }*/
    }

    public void closePage()
    {
        fishInfo.SetActive(false);
    }

    public void Update()
    {
        pageController.curPage = pageVal;
    }

}
