using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectFishMenu : MonoBehaviour
{
    
    private int currentIndex;
    private List<GameObject> buttons = new List<GameObject>();
    private List<GameObject> actualButtons = new List<GameObject>();

    public GameObject fishButtonPrefab;

    public SaveFile saveSystem;

    public string[] saveFileText;

    private void Start()
    {
        Debug.Log("wow");
        saveFileText = saveSystem.loadFile();
        Debug.Log(saveFileText.Length);
        Debug.Log(saveFileText);
    }

    public int CurrentIndex => currentIndex;

    public void refreshMenu()
    {
        Debug.Log("WOW");
        for(int i = actualButtons.Count - 1; i >= 0; i--)
        {
            GameObject.Destroy(actualButtons[i]);
            actualButtons.Remove(actualButtons[i]);
        }
        for(int i = buttons.Count - 1; i >= 0; i--)
        {
            buttons.Remove(buttons[i]);
        }

        for(int i = 0; i < saveFileText.Length; i++)
        {
            Debug.Log(saveFileText[i]);
            Debug.Log(string.Equals(saveFileText[i].Trim(), "Fish"));
            if(string.Equals(saveFileText[i].Trim(), "Fish"))
            {
                Debug.Log("Fishy");
                buttons.Add(fishButtonPrefab);
            }
        }

        Debug.Log("Buttons #:" + buttons.Count);
        
        for(int i = 0; i < buttons.Count; i++)
        {
            //every four because remainder will be 0123 so yeah.
            int j = i % 4;
            actualButtons.Add(Instantiate(buttons[i], new Vector3(transform.position.x + ((j % 2) * 180) - 90, transform.position.y - (((j > 1 ? 1 : 0) * 130) + 50), 0), transform.rotation, transform));
            if(i >= 4)
            {
                actualButtons[i].SetActive(false);
            }
        }

        Debug.Log("Buttons #real:" + actualButtons.Count);
        for(int i = 0; i < actualButtons.Count; i++)
        {
            Debug.Log("Broken for loop index: " + i);
            int fishCount = 0;
            for(int x = 0; x < saveFileText.Length; x++)
            {
                
                if(saveFileText[x].Trim() == "Fish")
                {
                    fishCount++;
                }
                if(fishCount == i + 1)
                {
                    Debug.Log("current x index: " + x);
                    bool quickCheckActive = false;
                    if(actualButtons[i].activeSelf == false)
                    {
                        quickCheckActive = true;
                        actualButtons[i].SetActive(true);
                    }
                    actualButtons[i].GetComponent<ImportImageLoad>().returnFishSprite(saveFileText[x + 2]);
                    Debug.Log(actualButtons[i].GetComponent<Image>().sprite);
                    actualButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = saveFileText[x + 1];
                    actualButtons[i].GetComponent<ImportImageLoad>().fishName = saveFileText[x + 1];
                    x = saveFileText.Length;
                    actualButtons[i].GetComponent<ImportImageLoad>().saveFileText = saveFileText;
                    actualButtons[i].GetComponent<ImportImageLoad>().quickCheckActive = quickCheckActive;
                }
                Debug.Log("Fish Count: " + fishCount);
            }
        }
        currentIndex = 3;
    }

    public void nextPage()
    {
        if(actualButtons.Count > currentIndex + 1)
        {
            for(int i = currentIndex - 3; i <= currentIndex; i++)
            {
                actualButtons[i].SetActive(false);
            }
            for(int i = currentIndex + 1; i < actualButtons.Count && i <= currentIndex + 4; i++)
            {
                actualButtons[i].SetActive(true);
            }
            currentIndex += 4;
        }
    }

    public void previousPage()
    {
        if(currentIndex > 3)
        {
            for(int i = currentIndex - 3; i <= currentIndex && i < actualButtons.Count; i++)
            {
                actualButtons[i].SetActive(false);
            }
            currentIndex -= 4;
            for(int i = currentIndex - 3; i <= currentIndex; i++)
            {
                actualButtons[i].SetActive(true);
            }
            
        }
    }
}
