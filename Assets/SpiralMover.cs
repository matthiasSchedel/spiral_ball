using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMover : MonoBehaviour
{
    private Vector3[] spiralVertices;

    private int spiralPointer = 0;
    private Transform tr;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float h_direction;
    [SerializeField]
    private float v_direction;

    SoundController sound;
    GameController game;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        game = FindObjectOfType<GameController>();
        sound = FindObjectOfType<SoundController>();


        //        Debug.Log("Length " + spiralVertices.Length);
        SetTransform();
    }

    void SetTransform()
    {
        spiralVertices = FindObjectOfType<Spiral>().getVertices();
        tr.position = spiralVertices[spiralPointer];
        tr.position = new Vector3(tr.position.x, tr.position.z, -2);
    }
    // Update is called once per frame
    void Update()
    {
        h_direction = Input.GetAxisRaw("Horizontal");
        v_direction = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        tr.RotateAround(tr.position, Vector3.forward, -h_direction * 5);
        if (v_direction != 0)
        {
            spiralPointer += (int)(v_direction * moveSpeed);
            spiralPointer = Mathf.Clamp(spiralPointer, 0, spiralVertices.Length - 1);
            SetTransform();
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        sound.PlaySound("playerExplode");
        GetComponent<ParticleSystem>().Play();
        Invoke("WaitDie", 3);
    }

    void WaitDie()
    {
        game.GameOver();
    }
}
