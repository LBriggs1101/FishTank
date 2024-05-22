using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImportImageLoad : MonoBehaviour
{
    string path;
    private Sprite convertedSprite;
    private Texture2D actualTexture;
    public SpriteRenderer sr;
    public SaveFile saveSystem;

    public string[] saveFileText;

    public GameObject prefabGuppy;
    public GameObject prefabDeepGuppy;
    public GameObject prefabLazy;
    public GameObject prefabDeepLazy;
    public GameObject prefabErratic;
    public GameObject prefabJelly;
    public GameObject prefabCrab;

    private GameObject objectToSpawn;
    private Vector3 spawnLocation;
    private float scaleMultiplyer;

    private void Start()
    {
        saveFileText = saveSystem.loadFile();
    }

    public void loadFish()
    {

        switch(int.Parse(saveFileText[4]))
        {
            case 0:
                objectToSpawn = prefabGuppy;
                break;
            case 1:
                objectToSpawn = prefabDeepGuppy;
                break; 
            case 2:
                objectToSpawn = prefabLazy;
                break;
            case 3:
                objectToSpawn = prefabDeepLazy;
                break;
            case 4:
                objectToSpawn = prefabErratic;
                break;
            case 5:
                objectToSpawn = prefabJelly;
                break;
            case 6:
                objectToSpawn = prefabCrab;
                break;
        }

        if(int.Parse(saveFileText[4]) == 1 || int.Parse(saveFileText[4]) == 3 || int.Parse(saveFileText[4]) == 6)
        {
            spawnLocation = new Vector3(0, -3, 0);
        }
        else
        {
            spawnLocation = new Vector3(0, 0, 0);
        }

        GameObject currentNewFish = Instantiate(objectToSpawn, spawnLocation , Quaternion.identity);

        sr = currentNewFish.GetComponent<SpriteRenderer>();

        if(int.Parse(saveFileText[4]) < 5)
        {
            currentNewFish.GetComponent<Wanderer>().moveSpeed = int.Parse(saveFileText[5]);
        }
        else if(int.Parse(saveFileText[4]) == 5)
        {
            currentNewFish.GetComponent<JellyfishAI>().moveSpeed = int.Parse(saveFileText[5]);
        }
        else
        {
            currentNewFish.GetComponent<CrabAI>().moveSpeed = int.Parse(saveFileText[5]);
        }

        if(int.Parse(saveFileText[6]) == 0)
        {
            scaleMultiplyer = 6;
        }
        else if(int.Parse(saveFileText[6]) == 1)
        {
            scaleMultiplyer = 4;
        }
        else
        {
            scaleMultiplyer = 2;
        }
        
        path = saveFileText[3];

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
            convertedSprite = Sprite.Create(actualTexture, new Rect(0.0f, 0.0f, actualTexture.width, actualTexture.height), new Vector2(0.5f, 0.5f), actualTexture.width * scaleMultiplyer);
            Debug.Log(convertedSprite);
            sr.sprite = convertedSprite;
        }
    }
}
