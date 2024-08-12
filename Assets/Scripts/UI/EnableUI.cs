using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUI : MonoBehaviour
{
    public PlayerInv uiThing;
    public GameObject shopButton;
    public GameObject disableButton;
    public GameObject backButton;
    public GameObject resetBGButton;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            if(uiThing.hideUI)
            {
                uiThing.enableUI();
                shopButton.SetActive(true);
                disableButton.SetActive(true);
                backButton.SetActive(true);
                resetBGButton.SetActive(true);
            }
        }
    }
}
