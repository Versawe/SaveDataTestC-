using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    //private string path = "C:/Users/ericv/Desktop/test";

    private string localFolder = "";
    private string roamingFolder = "";

    private string saveHere = "";

    private void Start()
    {
        localFolder = Directory.localFolder;
        roamingFolder = Directory.roamingFolder;
        saveHere = Application.persistentDataPath;

        //print("Local Folder: " + localFolder);
        //print("Roaming Folder: " + roamingFolder);

        //print("Persistant Data Path: " + Application.persistentDataPath);
        //print(SlotSave.fileLoaded);
    }
    public void CreateFile()
    {
        string dataLocation = saveHere + "/Data.txt";
        if (!File.Exists(dataLocation)) {
            System.IO.File.WriteAllText(dataLocation, "Hello World\nI love you\nAnd miss you");
            print("created");
        }
        else
        {
            print("File Already created");
            foreach(string line in System.IO.File.ReadLines(dataLocation))
            {
                print(line);
            }
            //print(System.IO.File.ReadLines(dataLocation));
        }

    }

    public void DeleteFile()
    {
        string dataLocation = saveHere + "/Data.txt";
        if (File.Exists(dataLocation))
        {
            System.IO.File.Delete(dataLocation);
            print("Deleted");
        }
        else
        {
            print("File Already gone");
        }
    }
}
