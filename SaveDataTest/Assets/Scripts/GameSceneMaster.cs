using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class GameSceneMaster : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Cube;
    public GameObject Cylinder;

    public string grabFilePath = "";
    public string geometryName = "";

    void Start()
    {
        grabFilePath = Application.persistentDataPath + "/" + NoDestroy.fileLoaded;

        //if(NoDestroy.fileLoaded == "Slot1Data.txt") Instantiate(Cube, Vector3.zero, Quaternion.identity);
        //if (NoDestroy.fileLoaded == "Slot2Data.txt") Instantiate(Cylinder, Vector3.zero, Quaternion.identity);
        //if (NoDestroy.fileLoaded == "Slot3Data.txt") Instantiate(Sphere, Vector3.zero, Quaternion.identity);
        print(NoDestroy.fileLoaded);

        geometryName = System.IO.File.ReadAllLines(grabFilePath)[1];
        print(geometryName);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SlotScene");
    }
}
