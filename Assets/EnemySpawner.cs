using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Transform enemyParent;

    [SerializeField]
    Vector3[] spawnPositions;

    [SerializeField]
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyParent = FindObjectOfType<EnemyParent>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float r = Random.Range(0, 100);
        if (r > 98)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float r = Random.Range(0, 2);
        int type = 0;
        if (r > 0.8)
        {
            //type = SpawnEnemyShip();
        }
        else if (r > 0.2)
        {
            type = 1; // SpawnAsteroid();
        }
        else
        {
            type = 2; // SpawnCoin();
        }

        int r2 = (int)(r * 10);
        int r3 = (int)(r * 100);
        int pos = 0;
        if (r2 % 2 == 2 && r3 % 2 == 2)
        {
            pos = 3;
        }
        else if (r2 % 2 == 2 && r3 % 2 == 2)
        {
            pos = 2;
        }
        else if (r2 % 2 == 2 && r3 % 2 == 2)
        {
            pos = 1;
        }
        SpawnEnemy(type, pos);
       


    }

    void SpawnEnemy(int type, int position)
    {
        float vxr = Random.Range(-3, 3);
        float vyr = Random.Range(-3, 3);
        Vector2 vel = (Vector2.zero + new Vector2(vxr, vyr) ) - new Vector2(spawnPositions[position].x, spawnPositions[position].y);
        float xr = Random.Range(-3,3);
        float yr = Random.Range(-3, 3);
        GameObject playerGameObject = Instantiate(enemies[type], spawnPositions[position] + new Vector3(xr, yr,0), transform.rotation);
        playerGameObject.transform.SetParent(enemyParent);
        playerGameObject.GetComponent<Rigidbody2D>().velocity = .2f * vel; // (new Vector2(transform.right.x, transform.right.y));
    }

    void SpawnEnemyShip()
    {

    }

    void SpawnAsteroid()
    { }

    void SpawnCoin()
    {
    }

}
