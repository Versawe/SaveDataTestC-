using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using System.IO;

public class InGameUI : MonoBehaviour
{
    public Button tinyBackButt;
    public Button changeGeoButt;
    public Button backButt;
    public Button cubeButt;
    public Button sphereButt;
    public Button cylinderButt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGeometryClicked()
    {
        tinyBackButt.gameObject.SetActive(true);
        cubeButt.gameObject.SetActive(true);
        sphereButt.gameObject.SetActive(true);
        cylinderButt.gameObject.SetActive(true);

        changeGeoButt.gameObject.SetActive(false);
        backButt.gameObject.SetActive(false);
    }

    public void TinyBackClicked()
    {
        tinyBackButt.gameObject.SetActive(false);
        cubeButt.gameObject.SetActive(false);
        sphereButt.gameObject.SetActive(false);
        cylinderButt.gameObject.SetActive(false);

        changeGeoButt.gameObject.SetActive(true);
        backButt.gameObject.SetActive(true);
    }

    public void ChangeToCube()
    {
        string persistantPath = Application.persistentDataPath + "/" + NoDestroy.fileLoaded;
        if (!System.IO.File.Exists(persistantPath)) return;

        string[] arrline = System.IO.File.ReadAllLines(persistantPath);
        arrline[1] = "Cube";
        string newString = "";
        foreach(string e in System.IO.File.ReadAllLines(persistantPath))
        {
            newString = newString + e;
        }

        //System.IO.File.Delete(persistantPath);
        //System.IO.File.WriteAllText(persistantPath, arrline);

    }
}
