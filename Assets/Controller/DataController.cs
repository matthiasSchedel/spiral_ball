using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    private static DataController instance = null;

    DataController()
    {
    }

 
    bool KeyExist(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
    void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public static DataController GetInstance()
    {
        if (instance == null)
        {
            instance = new DataController();
        }

        return instance;
    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
