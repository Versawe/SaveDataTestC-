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

        foreach (string e in System.IO.File.ReadAllLines(grabFilePath))
        {
            print(e);
        }

        if (!System.IO.File.Exists(grabFilePath))
        {
            print("file not there");
            SceneManager.LoadScene("SlotScene");
            return;
        }
        //print(NoDestroy.fileLoaded);

        geometryName = System.IO.File.ReadAllLines(grabFilePath)[1];
        //print(geometryName);

        Instantiate(Resources.Load("Prefabs/"+geometryName), Vector3.zero, Quaternion.identity);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SlotScene");
    }
}
