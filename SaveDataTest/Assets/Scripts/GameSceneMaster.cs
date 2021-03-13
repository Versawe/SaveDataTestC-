using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

//this script checks the text file assocaited with the slot the user chooses
//it loads the correct geometry based on what is saved there
public class GameSceneMaster : MonoBehaviour
{
    //variables
    public string grabFilePath = "";
    public string geometryName = "";

    void Start()
    {
        // gets persistant path and adds the file loaded static var on the DoNotDestroy Game Object
        grabFilePath = Application.persistentDataPath + "/" + NoDestroy.fileLoaded;

        //if file does not exist load back to main menu (could add error message to appear here)
        if (!System.IO.File.Exists(grabFilePath))
        {
            print("file not there");
            SceneManager.LoadScene("SlotScene");
            return;
        }

        //This grabs the second line of the data text file
        geometryName = System.IO.File.ReadAllLines(grabFilePath)[1];

        //loads the prefab with the same name as the geometryName string. At (0,0,0) with (0,0,0) rotation
        Instantiate(Resources.Load("Prefabs/"+geometryName), Vector3.zero, Quaternion.identity);
    }
    //function to load main menu scene
    public void LoadScene()
    {
        SceneManager.LoadScene("SlotScene");
    }
}
