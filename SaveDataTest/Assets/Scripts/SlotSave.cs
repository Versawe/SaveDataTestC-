using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using UnityEngine.UI;

public class SlotSave : MonoBehaviour
{

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

    GameObject controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("NODESTROY");
        persistentPath = Application.persistentDataPath;
        if (File.Exists(persistentPath + "/Slot1Data.txt")) slot1Exists = true;
        if (File.Exists(persistentPath + "/Slot2Data.txt")) slot2Exists = true;
        if (File.Exists(persistentPath + "/Slot3Data.txt")) slot3Exists = true;

        if (slot1Exists || slot2Exists || slot3Exists) ContinueButt.gameObject.SetActive(true);
        else ContinueButt.gameObject.SetActive(false);

        if (!slot1Exists || !slot2Exists || !slot3Exists) NewButt.gameObject.SetActive(true);
        else NewButt.gameObject.SetActive(false);

    }

    public void SelectEmptySlot()
    {
        if(File.Exists(persistentPath + "/Slot1Data.txt") && File.Exists(persistentPath + "/Slot2Data.txt") && File.Exists(persistentPath + "/Slot3Data.txt")) return;

        BackButt.gameObject.SetActive(true);
        NewButt.gameObject.SetActive(false);
        ContinueButt.gameObject.SetActive(false);
        if (!File.Exists(persistentPath + "/Slot1Data.txt")) Slot1Butt.gameObject.SetActive(true);
        if (!File.Exists(persistentPath + "/Slot2Data.txt")) Slot2Butt.gameObject.SetActive(true);
        if (!File.Exists(persistentPath + "/Slot3Data.txt")) Slot3Butt.gameObject.SetActive(true);
    }

    public void BackTrigger()
    {
        BackButt.gameObject.SetActive(false);
        Slot1Butt.gameObject.SetActive(false);
        Slot2Butt.gameObject.SetActive(false);
        Slot3Butt.gameObject.SetActive(false);
        NoDestroy.fileLoaded = "";

        if (File.Exists(persistentPath + "/Slot1Data.txt") || File.Exists(persistentPath + "/Slot2Data.txt") || File.Exists(persistentPath + "/Slot3Data.txt")) ContinueButt.gameObject.SetActive(true);
        if (!File.Exists(persistentPath + "/Slot1Data.txt") || !File.Exists(persistentPath + "/Slot2Data.txt") || !File.Exists(persistentPath + "/Slot3Data.txt")) NewButt.gameObject.SetActive(true);
    }

    public void CreateSlot1()
    {
        if (slot1Exists)
        {
            foreach (string line in System.IO.File.ReadLines(persistentPath + "/Slot1Data.txt"))
            {
                print(line);
            }
            NoDestroy.fileLoaded = "Slot1Data.txt";
            SceneManager.LoadScene("GameScene");
            return;
        }

        System.IO.File.WriteAllText(persistentPath + "/Slot1Data.txt", "Slot 1 Data\nCube");
        Slot1Butt.gameObject.SetActive(false);
        slot1Exists = true;
        NoDestroy.fileLoaded = "Slot1Data.txt";
        SceneManager.LoadScene("GameScene");
    }

    public void CreateSlot2()
    {
        if (slot2Exists)
        {
            foreach (string line in System.IO.File.ReadLines(persistentPath + "/Slot2Data.txt"))
            {
                print(line);
            }
            NoDestroy.fileLoaded = "Slot2Data.txt";
            SceneManager.LoadScene("GameScene");
            return;
        }

        System.IO.File.WriteAllText(persistentPath + "/Slot2Data.txt", "Slot 2 Data\nCylinder");
        Slot2Butt.gameObject.SetActive(false);
        slot2Exists = true;
        NoDestroy.fileLoaded = "Slot2Data.txt";
        SceneManager.LoadScene("GameScene");
    }

    public void CreateSlot3()
    {
        if (slot3Exists)
        {
            foreach (string line in System.IO.File.ReadLines(persistentPath + "/Slot3Data.txt"))
            {
                print(line);
            }
            NoDestroy.fileLoaded = "Slot3Data.txt";
            SceneManager.LoadScene("GameScene");
            return;
        }

        System.IO.File.WriteAllText(persistentPath + "/Slot3Data.txt", "Slot 3 Data\nSphere");
        Slot3Butt.gameObject.SetActive(false);
        slot3Exists = true;
        NoDestroy.fileLoaded = "Slot3Data.txt";
        SceneManager.LoadScene("GameScene");
    }

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
