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

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Import your fish png", "", "png, jpg");
        GetImage();
    }

    void GetImage()
    {
        if(path != null)
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
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
            image.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
