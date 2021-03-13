using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using UnityEngine.UI;

public class SlotSave : MonoBehaviour
{
    //variables
    public string persistentPath = "";

    public Button Slot1Butt;
    public Button Slot2Butt;
    public Button Slot3Butt;

    public Button ContinueButt;
    public Button NewButt;
    public Button BackButt;

    public bool slot1Exists = false;
    public bool slot2Exists = false;
    public bool slot3Exists = false;

    //no destroy object
    GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        //grab no destroy object
        controller = GameObject.Find("NODESTROY");
        //gets persistant path
        persistentPath = Application.persistentDataPath;

        //if the files exist change the bool
        if (File.Exists(persistentPath + "/Slot1Data.txt")) slot1Exists = true;
        if (File.Exists(persistentPath + "/Slot2Data.txt")) slot2Exists = true;
        if (File.Exists(persistentPath + "/Slot3Data.txt")) slot3Exists = true;

        //makes continue button visable if there is an existing data file to continue game on
        if (slot1Exists || slot2Exists || slot3Exists) ContinueButt.gameObject.SetActive(true);
        else ContinueButt.gameObject.SetActive(false);

        //if there are no more save slots available the new game button will not appear
        if (!slot1Exists || !slot2Exists || !slot3Exists) NewButt.gameObject.SetActive(true);
        else NewButt.gameObject.SetActive(false);
    }

    //This function activates if you click new game button
    //it makes sure only empty slot buttons show up
    public void SelectEmptySlot()
    {
        //returns out if all files exist
        if(File.Exists(persistentPath + "/Slot1Data.txt") && File.Exists(persistentPath + "/Slot2Data.txt") && File.Exists(persistentPath + "/Slot3Data.txt")) return;

        //updates gui's accordingly
        BackButt.gameObject.SetActive(true);
        NewButt.gameObject.SetActive(false);
        ContinueButt.gameObject.SetActive(false);
        if (!File.Exists(persistentPath + "/Slot1Data.txt")) Slot1Butt.gameObject.SetActive(true);
        if (!File.Exists(persistentPath + "/Slot2Data.txt")) Slot2Butt.gameObject.SetActive(true);
        if (!File.Exists(persistentPath + "/Slot3Data.txt")) Slot3Butt.gameObject.SetActive(true);
    }

    //triggers if you click the back button
    public void BackTrigger()
    {
        //updates gui
        BackButt.gameObject.SetActive(false);
        Slot1Butt.gameObject.SetActive(false);
        Slot2Butt.gameObject.SetActive(false);
        Slot3Butt.gameObject.SetActive(false);
        //clears static vairable (may not be needed)
        NoDestroy.fileLoaded = "";

        // makes sure when clicking back button that continue button or new game button should appear accodingly
        if (File.Exists(persistentPath + "/Slot1Data.txt") || File.Exists(persistentPath + "/Slot2Data.txt") || File.Exists(persistentPath + "/Slot3Data.txt")) ContinueButt.gameObject.SetActive(true);
        if (!File.Exists(persistentPath + "/Slot1Data.txt") || !File.Exists(persistentPath + "/Slot2Data.txt") || !File.Exists(persistentPath + "/Slot3Data.txt")) NewButt.gameObject.SetActive(true);
    }

    //function for clicking slot 1
    public void CreateSlot1()
    {
        //if the file exists changes the static variable and loads the scene
        if (File.Exists(persistentPath + "/Slot1Data.txt"))
        {
            NoDestroy.fileLoaded = "Slot1Data.txt";
            SceneManager.LoadScene("GameScene");
        }
        //if the file does not exist changes the static variable and loads the scene
        //also creates and writes to the text file
        else if (!File.Exists(persistentPath + "/Slot1Data.txt"))
        {
            System.IO.File.WriteAllText(persistentPath + "/Slot1Data.txt", "Slot 1 Data\nCube");
            Slot1Butt.gameObject.SetActive(false);
            NoDestroy.fileLoaded = "Slot1Data.txt";
            SceneManager.LoadScene("GameScene");
        }
    }

    //function for clicking slot 2
    public void CreateSlot2()
    {
        //if the file exists changes the static variable and loads the scene
        if (File.Exists(persistentPath + "/Slot2Data.txt"))
        {
            NoDestroy.fileLoaded = "Slot2Data.txt";
            SceneManager.LoadScene("GameScene");
        }
        //if the file does not exist changes the static variable and loads the scene
        //also creates and writes to the text file
        else if (!File.Exists(persistentPath + "/Slot2Data.txt"))
        {
            System.IO.File.WriteAllText(persistentPath + "/Slot2Data.txt", "Slot 2 Data\nCylinder");
            Slot2Butt.gameObject.SetActive(false);
            NoDestroy.fileLoaded = "Slot2Data.txt";
            SceneManager.LoadScene("GameScene");
        }
    }

    //function for clicking slot 3
    public void CreateSlot3()
    {
        //if the file exists changes the static variable and loads the scene
        if (File.Exists(persistentPath + "/Slot3Data.txt"))
        {
            NoDestroy.fileLoaded = "Slot3Data.txt";
            SceneManager.LoadScene("GameScene");
        }
        //if the file does not exist changes the static variable and loads the scene
        //also creates and writes to the text file
        else if (!File.Exists(persistentPath + "/Slot3Data.txt"))
        {
            System.IO.File.WriteAllText(persistentPath + "/Slot3Data.txt", "Slot 3 Data\nSphere");
            Slot3Butt.gameObject.SetActive(false);
            NoDestroy.fileLoaded = "Slot3Data.txt";
            SceneManager.LoadScene("GameScene");
        }
    }

    //when user clicks continue (same logic as SelectEmptySlot() function)
    public void ContinueTrigger()
    {
        if (!File.Exists(persistentPath + "/Slot1Data.txt") && !File.Exists(persistentPath + "/Slot2Data.txt") && !File.Exists(persistentPath + "/Slot3Data.txt")) return;

        BackButt.gameObject.SetActive(true);
        NewButt.gameObject.SetActive(false);
        ContinueButt.gameObject.SetActive(false);
        if (File.Exists(persistentPath + "/Slot1Data.txt")) Slot1Butt.gameObject.SetActive(true);
        if (File.Exists(persistentPath + "/Slot2Data.txt")) Slot2Butt.gameObject.SetActive(true);
        if (File.Exists(persistentPath + "/Slot3Data.txt")) Slot3Butt.gameObject.SetActive(true);
    }
}
