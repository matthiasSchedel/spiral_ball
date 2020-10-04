using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{

    private static MusicController instance = null;


    [SerializeField]
    private Dictionary<string, AudioClip> audioClips;

    [SerializeField]
    private AudioClip menuMusic;

    [SerializeField]
    private AudioClip levelMusic;

    [SerializeField]
    private AudioClip gameOverMusic;

    private AudioSource source;

    public static MusicController GetInstance()
    {
        if (instance == null)
        {
            instance = new MusicController();
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
