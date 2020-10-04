using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    private static SoundController instance = null;
    private AudioClip clip;
    private AudioSource source1;
    private AudioSource source2;


    [SerializeField]
    private Dictionary<string, AudioClip> audioClips;

    [SerializeField]
    private AudioClip playerShoot;

    [SerializeField]
    private AudioClip select;

    [SerializeField]
    private AudioClip asteroidExplode;

    [SerializeField]
    private AudioClip playerExplode;

    [SerializeField]
    private AudioClip powerup;

    [SerializeField]
    private AudioClip playerHit;

    [SerializeField]
    private AudioClip pickupCoin;

    [SerializeField]
    private AudioClip startLevel;

    SoundController()
    {
       
    }

    void Awake()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        source1 = sources[0];
        source2 = sources[1];
        audioClips = new Dictionary<string, AudioClip>();
        audioClips.Add("playerShoot", playerShoot);
        audioClips.Add("select", select);
        audioClips.Add("asteroidExplode", asteroidExplode);
        audioClips.Add("playerExplode", playerExplode);
        audioClips.Add("powerup", powerup);
        audioClips.Add("playerHit", playerHit);
        audioClips.Add("pickupCoin", pickupCoin);
        audioClips.Add("startLevel", startLevel);
    }

    public void PlaySound(string clip)

    {
        if (audioClips.ContainsKey(clip))
           {
            AudioClip audio;
            audioClips.TryGetValue(clip, out audio);
            source1.clip = audio;
            source1.Play();
            
        }
        
      
    }


    public static SoundController GetInstance()
    {
        if (instance == null)
        {
            instance = new SoundController();
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
