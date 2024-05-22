using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile : MonoBehaviour
{
    private string directory;
    
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

    public string[] loadFile()
    {
        StreamReader reader = new StreamReader(directory);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines;
    }
}
