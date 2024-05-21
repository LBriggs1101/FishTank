using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveTest : MonoBehaviour
{

    public SaveFile saveSystem;

    public TMP_Dropdown dropDown;

    public TMP_Dropdown dropDownSize;

    public TMP_InputField inputFieldName;

    public TMP_InputField inputFieldSpeed;

    public ImportImagePath imageImportObject;

    public string fishPath = "";
    public string fishName = "";

    public int fishType = 0;
    public int fishSpeed = 1;
    public int fishSize = 0;

    public GameObject failText;

    public void changeFishType()
    {
        fishType = dropDown.value;
    }

    public void changeFishSize()
    {
        fishSize = dropDownSize.value;
    }

    public void changeFishName()
    {
        fishName = inputFieldName.text;
    }

    public void changeFishSpeed()
    {
        fishSpeed = int.Parse(inputFieldSpeed.text);
    }

    public void saveTest()
    {
        if((fishPath != null && fishPath != "") && (fishName != null && fishName != ""))
        {
            saveSystem.saveNewFish(fishPath, fishName, fishType, fishSpeed, fishSize);
            imageImportObject.MoveImageForSave();
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            failText.SetActive(true);
            StartCoroutine(timedDisableText());
        }
    }

    private IEnumerator timedDisableText()
    {
        yield return new WaitForSecondsRealtime(2f);
        failText.SetActive(false);
    }
}
