using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{

    public SaveFile saveSystem;

    public void saveTest()
    {
        saveSystem.saveNewFish("Path", "Kyle", 1, 1, 1);
    }
}
