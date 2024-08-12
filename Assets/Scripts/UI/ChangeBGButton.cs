using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class ChangeBGButton : MonoBehaviour
{
    public GameObject normalBG;
    public GameObject customBG;
    public SpriteRenderer sr;

    public string[] saveFileText;

    private Texture2D actualTexture;
    private Sprite convertedSprite;

    public SaveFile saveSystem;

    public string path;
    public string bgName;

    public int fileLocation;

    public bool quickCheckActive = false;

    private void Start() {
        saveFileText = saveSystem.loadFile();
    }

    public void returnBGSprite(string newPath)
    {
        path = newPath;

        StartCoroutine(DownloadImageReturnSprite());
    }

    public void loadBG()
    {
        GameObject.Find("Ocean Background").SetActive(false);
        sr = GameObject.Find("Ocean Background Custom").GetComponent<SpriteRenderer>();

        for(int i = 0; i < saveFileText.Length; i++)
        {
            if(string.Equals(saveFileText[i].Trim(), "Background"))
            {
                if(saveFileText[i + 1] == bgName)
                {
                    fileLocation = i + 1;
                    break;
                }
            }
        }

        path = saveFileText[fileLocation + 1];

        StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImage()
    {
        UnityWebRequest request  = UnityWebRequestTexture.GetTexture("file:///" + path);
        Debug.Log(path);
        yield return request.SendWebRequest();

        if((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Work?");
            Debug.Log(((DownloadHandlerTexture)request.downloadHandler).texture);
            actualTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            convertedSprite = Sprite.Create(actualTexture, new Rect(0.0f, 0.0f, actualTexture.width, actualTexture.height), new Vector2(0.5f, 0.5f), 100);
            Debug.Log(convertedSprite);
            sr.sprite = convertedSprite;
        }
    }

    IEnumerator DownloadImageReturnSprite()
    {
        UnityWebRequest request  = UnityWebRequestTexture.GetTexture("file:///" + path);
        Debug.Log(path);
        yield return request.SendWebRequest();

        if((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Work?");
            Debug.Log(((DownloadHandlerTexture)request.downloadHandler).texture);
            actualTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            
            gameObject.GetComponent<Image>().sprite = Sprite.Create(actualTexture, new Rect(0.0f, 0.0f, actualTexture.width, actualTexture.height), new Vector2(0.5f, 0.5f), actualTexture.width * 1);
            if(quickCheckActive == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
