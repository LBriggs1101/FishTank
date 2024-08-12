using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile : MonoBehaviour
{
    private string directory = Application.dataPath + "/SaveFolder/Save.txt";
    
    private void Start() 
    {
        directory = Application.dataPath + "/SaveFolder/Save.txt";
    }

    public void saveNewFish(string filePath, string fishName, int fishType, int fishSpeed, int fishSize)
    {
       File.AppendAllText(
        directory, 
        "\n" +
        "Fish" + "\n" +
        fishName + "\n" +
        filePath + "\n" +
        fishType.ToString() + "\n" +
        fishSpeed.ToString() + "\n" +
        fishSize.ToString() + "\n"

        );
    }

    public void saveNewBackground(string backgroundName, string filePath)
    {
        File.AppendAllText(
        directory, 
        "\n" +
        "Background" + "\n" +
        backgroundName + "\n" +
        filePath + "\n"    

        );
    }

    public string[] loadFile()
    {
        Debug.Log(directory);
        StreamReader reader = new StreamReader(directory);
        
        Debug.Log(reader);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines;
    }
}
