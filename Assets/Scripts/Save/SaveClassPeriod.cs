using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveClassPeriod : MonoBehaviour
{

    public ClassPeriodManager classPeriodManager;

    private string directory;

    private void Start() 
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            gameObject.GetComponent<ImportImageLoad>().saveFileText = loadFileHere();
            gameObject.GetComponent<ChangeBGButton>().saveFileText = loadFileHere();
            loadTankFish();
            loadClassBG();  
        }
        
    }
    
    //Method to append a save file (1-7) with a fish name
    public void saveTankFish(string fishName)
    {
        directory = Application.dataPath + "/SaveFolder/SavePeriod" + classPeriodManager.ClassPeriod + "Fish.txt";
        File.AppendAllText(directory, fishName + "\n");
    }

    //Method to load that save file (1-7) every line is a fish name
    public void loadTankFish()
    {
        string[] saveFile = loadFileClassPeriodFish();
        ImportImageLoad fishImporter = gameObject.GetComponent<ImportImageLoad>();
        for(int i = 0; i < saveFile.Length; i++)
        {
            if(saveFile[i] != "")
            {
                fishImporter.loadFishFromName(saveFile[i]);
            }
        }
    }

    //Method to overwrite a different save file (1-7) with the new background
    public void saveNewClassBG(string bgName)
    {
        directory = Application.dataPath + "/SaveFolder/SavePeriod" + classPeriodManager.ClassPeriod + "BG.txt";
        File.WriteAllText(directory, bgName);
    }

    //Method to load that different save file background
    public void loadClassBG()
    {
        string[] saveFile = loadFileClassPeriodBG();
        ChangeBGButton bgImporter = gameObject.GetComponent<ChangeBGButton>();
        
        if(saveFile[0] != "")
        {
            bgImporter.loadBGFromName(saveFile[0]);
        }
        
    }

    //Method to delete a specified class period
    public void deleteClassPeriod(int classPeriod)
    {
        directory = Application.dataPath + "/SaveFolder/SavePeriod" + classPeriod + "Fish.txt";
        File.WriteAllText(directory, string.Empty);
        directory = Application.dataPath + "/SaveFolder/SavePeriod" + classPeriod + "BG.txt";
        File.WriteAllText(directory, string.Empty);
    }

    //If possible delete specific fish in a class period but not likely, at least for this version. 

    public string[] loadFileClassPeriodFish()
    {
        directory = Application.dataPath + "/SaveFolder/SavePeriod" + classPeriodManager.ClassPeriod + "Fish.txt";
        Debug.Log(directory);
        StreamReader reader = new StreamReader(directory);
        
        Debug.Log(reader);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines;
    }

    public string[] loadFileClassPeriodBG()
    {
        directory = Application.dataPath + "/SaveFolder/SavePeriod" + classPeriodManager.ClassPeriod + "BG.txt";
        Debug.Log(directory);
        StreamReader reader = new StreamReader(directory);
        
        Debug.Log(reader);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines;
    }

    public string[] loadFileHere()
    {
        directory = Application.dataPath + "/SaveFolder/Save.txt";

        Debug.Log(directory);
        StreamReader reader = new StreamReader(directory);
        
        Debug.Log(reader);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines;
    }
}
