using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{

    [SerializeField]
    public GameObject projectile;
    private SoundController sound;
    private Transform particleParent;
    // Start is called before the first frame update
    void Start()
    {
        particleParent = FindObjectOfType<ProjectileParent>().transform;
        sound = FindObjectOfType<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        
    }

    void Fire()
    {
        GameObject playerGameObject = Instantiate(projectile, transform.position, transform.rotation);
        playerGameObject.transform.SetParent(particleParent);
        playerGameObject.GetComponent<Rigidbody2D>().velocity = 5*(new Vector2(transform.right.x, transform.right.y));
        //playerGameObject.transform.position = new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y, -2);
        sound.PlaySound("playerShoot");
        Debug.Log(transform.right);
    }
}
