using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveTestBackground : MonoBehaviour
{
    public SaveFile saveSystem;

    public TMP_InputField inputFieldName;

    public ImportImagePathBackground imageImportObject;

    public string backgroundPath = "";
    public string backgroundName = "";

    public GameObject failText;

    public void changeBackgroundName()
    {
        backgroundName = inputFieldName.text;
    }

    public void saveTest()
    {
        if((backgroundPath != null && backgroundPath != "") && (backgroundName != null && backgroundName != ""))
        {
            string[] tempFile = saveSystem.loadFile();
            if(tempFile != null)
            {
               for(int i = 0; i < tempFile.Length; i++)
                {
                    if(string.Equals(tempFile[i], "Background"))
                    {
                        if(tempFile[i + 1] == backgroundName)
                        {
                            failText.SetActive(true);
                            StartCoroutine(timedDisableText()); 
                            return;
                        }
                    }
                } 
            }
            
            saveSystem.saveNewBackground(backgroundName, backgroundPath);
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
