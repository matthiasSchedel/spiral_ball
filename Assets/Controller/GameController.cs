using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private GameObject exitObject;

    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private Vector3 spawnPosition;

    [SerializeField]
    private Vector3 exitPosition;

    private Player player;


    private int score;

    private int currentLevel;

    LevelController level;

    [SerializeField]
    private bool instantiatePlayer = false;




    private static GameController instance = null;
    void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");


        if (obj != null)
        {
            instance = obj.GetComponent<GameController>();
        }

        DontDestroyOnLoad(this.gameObject);

       



      
    }

    public void FinishLevel()
    {
        level.LoadLevel(currentLevel + 1);
    }

    public void GameOver()
    {
        level.LoadScene("GameOver");
    }

    private void SpawnPlayer()
    {
        GameObject playerGameObject = Instantiate(playerObject, spawnPosition, Quaternion.identity);
        FindObjectOfType<FollowPlayer>().SetTransform(playerGameObject.transform);
        //FindObjectOfType<Camera>().transform.parent = playerGameObject.transform;
    }

    public static GameController GetInstance()
    {
        if (instance == null)
        {
            instance = new GameController(); 
        }

        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<LevelController>();
        score = 0;
        currentLevel = 0;

        if (FindObjectOfType<Player>() == null && instantiatePlayer)
        {
            SpawnPlayer();
        }
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}