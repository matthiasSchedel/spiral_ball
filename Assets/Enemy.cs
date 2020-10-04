using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SoundController sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        sound.PlaySound("asteroidExplode");
        GetComponent<ParticleSystem>().Play();
        Invoke("WaitDie", 3);
    }

    void WaitDie()
    {
        Destroy(gameObject);
    }
}
