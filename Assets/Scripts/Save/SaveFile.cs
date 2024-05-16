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

    public void saveNewImage(string filePath)
    {
       File.WriteAllText(directory, filePath); 
    }

    public string loadImage()
    {
        StreamReader reader = new StreamReader(directory);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines[0];
    }
}
