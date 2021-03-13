using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

//This Script updates the data files
public class InGameUI : MonoBehaviour
{
    //Button vars
    public Button tinyBackButt;
    public Button changeGeoButt;
    public Button backButt;
    public Button cubeButt;
    public Button sphereButt;
    public Button cylinderButt;

    //Gui update functions
    //function changes the gui layout if you click the change geometry button
    public void ChangeGeometryClicked()
    {
        tinyBackButt.gameObject.SetActive(true);
        cubeButt.gameObject.SetActive(true);
        sphereButt.gameObject.SetActive(true);
        cylinderButt.gameObject.SetActive(true);

        changeGeoButt.gameObject.SetActive(false);
        backButt.gameObject.SetActive(false);
    }
    //function changes the gui layout if you click the small back button to get back to the main menu
    public void TinyBackClicked()
    {
        tinyBackButt.gameObject.SetActive(false);
        cubeButt.gameObject.SetActive(false);
        sphereButt.gameObject.SetActive(false);
        cylinderButt.gameObject.SetActive(false);

        changeGeoButt.gameObject.SetActive(true);
        backButt.gameObject.SetActive(true);
    }

    //Background functions that change the data file below
    //This changes current geometry on file to Cube
    public void ChangeToCube()
    {
        //grabs the persistant path and file of the selected slot
        string persistantPath = Application.persistentDataPath + "/" + NoDestroy.fileLoaded;
        if (!System.IO.File.Exists(persistantPath)) return; //exits out if the file does not exist

        string newString = "";

        //loop creates a new string and replaces the row that has geometry name in it
        for (int i = 0; i < System.IO.File.ReadAllLines(persistantPath).Length; i++)
        {
            if (i != 1) newString = newString + System.IO.File.ReadAllLines(persistantPath)[i];
            else newString = newString + "\nCube";
        }

        //This deletes the old file and replaces it with the updated new file
        System.IO.File.Delete(persistantPath);
        System.IO.File.WriteAllText(persistantPath, newString);

        //loads scene to start game
        SceneManager.LoadScene("GameScene");
    }

    //This changes current geometry on file to Cylinder
    public void ChangeToCylinder()
    {
        //grabs the persistant path and file of the selected slot
        string persistantPath = Application.persistentDataPath + "/" + NoDestroy.fileLoaded;
        if (!System.IO.File.Exists(persistantPath)) return; //exits out if the file does not exist

        string newString = "";

        //loop creates a new string and replaces the row that has geometry name in it
        for (int i = 0; i < System.IO.File.ReadAllLines(persistantPath).Length; i++)
        {
            if (i != 1) newString = newString + System.IO.File.ReadAllLines(persistantPath)[i];
            else newString = newString + "\nCylinder";
        }

        //This deletes the old file and replaces it with the updated new file
        System.IO.File.Delete(persistantPath);
        System.IO.File.WriteAllText(persistantPath, newString);

        //loads scene to start game
        SceneManager.LoadScene("GameScene");
    }

    //This changes current geometry on file to Sphere
    public void ChangeToSphere()
    {
        //grabs the persistant path and file of the selected slot
        string persistantPath = Application.persistentDataPath + "/" + NoDestroy.fileLoaded;
        if (!System.IO.File.Exists(persistantPath)) return; //exits out if the file does not exist

        string newString = "";

        //loop creates a new string and replaces the row that has geometry name in it
        for (int i = 0; i < System.IO.File.ReadAllLines(persistantPath).Length; i++)
        {
            if (i != 1) newString = newString + System.IO.File.ReadAllLines(persistantPath)[i];
            else newString = newString + "\nSphere";
        }

        //This deletes the old file and replaces it with the updated new file
        System.IO.File.Delete(persistantPath);
        System.IO.File.WriteAllText(persistantPath, newString);

        //loads scene to start game
        SceneManager.LoadScene("GameScene");
    }
}
