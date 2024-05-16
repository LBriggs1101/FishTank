using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.Networking;

public class ImportImagePath : MonoBehaviour
{
    string path;
    public RawImage image;
    private Sprite convertedSprite;
    private Texture2D actualTexture;
    public SpriteRenderer sr;
    public SaveFile saveSystem;
    private string newPicLocation;

    private void Start()
    {
        newPicLocation = Application.dataPath + "/fishImages/";
    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Import your fish png", "", "png, jpg");
        GetImage(1);
    }

    public void loadImage()
    {
        path = saveSystem.loadImage();
        GetImage(0);
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
            FileUtil.MoveFileOrDirectory(path, newPicLocation + Path.GetFileName(path));
            saveSystem.saveNewImage(newPicLocation + Path.GetFileName(path));
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
}
