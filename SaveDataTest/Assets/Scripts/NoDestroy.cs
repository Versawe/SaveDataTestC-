using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour
{
    public static string fileLoaded;

    private static GameObject instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
