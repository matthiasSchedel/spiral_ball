using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    public List<string> levelNames = new List<string>();
    private static LevelController instance = null;
    private SoundController sound;

    public static LevelController GetInstance()
    {
        if (instance == null)
        {
            instance = new LevelController();
        }

        return instance;
    }

    void Awake()
    {

        sound = FindObjectOfType<SoundController>();
    }


  public  void LoadLevel(int levelNo)
    {
        if (levelNo < levelNames.Count)
        {
            LoadScene(levelNames[levelNo]);

        }

    }
       public  void LoadScene(string scene)
        {
        if (sound != null) {
            sound.PlaySound("select");

        }
        SceneManager.LoadScene(scene);
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

