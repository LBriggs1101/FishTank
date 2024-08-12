using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.Networking;
using AnotherFileBrowser.Windows;
using TMPro;

public class ImportImagePathBackground : MonoBehaviour
{
    string path;
    public RawImage image;
    private Sprite convertedSprite;
    private Texture2D actualTexture;
    public SpriteRenderer sr;
    public SaveFile saveSystem;
    private string newPicLocation;

    public SaveTestBackground saveObject;

    public TMP_Text pathText;

    private void Start()
    {
        newPicLocation = Application.dataPath + "/fishImages/";
    }

    public void OpenExplorer()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.png) | *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, bpath =>
        {
            path = bpath;
        });
        GetImage(1);
    }

    

    void GetImage(int num)
    {
        if(path != null)
        {
            if(num == 1)
                UpdateImage();
            else
                UpdateImageNotNew();
        }
    }

    void UpdateImage()
    {
        StartCoroutine(DownloadImageFirst());
    }

    void UpdateImageNotNew()
    {
        StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImageFirst()
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
            image.texture = actualTexture;
            convertedSprite = Sprite.Create(actualTexture, new Rect(0.0f, 0.0f, actualTexture.width, actualTexture.height), new Vector2(0.5f, 0.5f), actualTexture.width);
            Debug.Log(convertedSprite);
            sr.sprite = convertedSprite;
            pathText.text = path;
            saveObject.backgroundPath = newPicLocation + Path.GetFileName(path);
        }
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
            image.texture = actualTexture;
            convertedSprite = Sprite.Create(actualTexture, new Rect(0.0f, 0.0f, actualTexture.width, actualTexture.height), new Vector2(0.5f, 0.5f), actualTexture.width);
            Debug.Log(convertedSprite);
            sr.sprite = convertedSprite;
        }
    }

    public void MoveImageForSave()
    {
        File.Move(path, newPicLocation + Path.GetFileName(path));
    }
}
