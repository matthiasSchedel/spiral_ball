using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public ParticleSystem tpc;
    private Transform tr;
    private SpiralBackground spiralBg;

    private SoundController sound;

    [SerializeField]
    private Vector3 accelerationV = Vector3.zero;

    //[SerializeField]
    private float acceleration = 5f;

    float maxVelocity = 20f;

    [SerializeField]
    public float moveSpeed = .0003f;
    [SerializeField]
    public float dragSpeed = 1.0f;
    [SerializeField]
    private float h_direction;
    [SerializeField]
    private float v_direction;

    private float max_v = 10f;

    private float max_h = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        spiralBg = FindObjectOfType<SpiralBackground>();
        tpc = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        h_direction = Input.GetAxisRaw("Horizontal");
        v_direction = Input.GetAxisRaw("Vertical");
        CheckBoundaries();
        //if (CheckBoundaries())
        {
            //Debug.Log("boundary !!!");
        }

    }

    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        //rb.velocity = Vector2.zero;
        tr.RotateAround(tr.position, Vector3.forward, -h_direction * 5);
        //Debug.Log(transform.forward);
        //Debug.Log(transform.position);
        //h_direction * Time.fixedTime * moveSpeed


        //#rb.velocity += new Vector2(vel.x, vel.y);
        //Drag();
        ThrustForward(v_direction * acceleration);
        //Boost();

       // float x = Mathf.Clamp(transform.position.x, -max_h, max_h);
        //float y = Mathf.Clamp(transform.position.y, -max_v, max_v);
        //tr.position = new Vector3(x, y, -2);
    }

    private void Explode() {
        tpc.Play();
    }
    private bool CheckBoundaries()
    {
        // Debug.Log("checkB");
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, Vector3.forward, 1000.0F);
        Debug.Log("Hits length" + hits.Length);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            MeshRenderer rend = hit.transform.GetComponent<MeshRenderer>();
            Debug.Log("Hits " + hits[i]);
            Debug.Log(hits[i].collider.name);
            if (hits[i].collider.name == "spiral")
            {
                Explode();
                return false;
            }
            return false;
            if (rend)
            {
                // Change the material of all hit colliders
                // to use a transparent shader.
                //rend.material.shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = rend.material.color;
                Texture texture = rend.material.mainTexture;
                RenderTexture texture2DTest = (texture as RenderTexture);
                //Color pixel = texture2DTest.GetPixel(100, 100);
                RenderTexture tex = rend.material.mainTexture as RenderTexture;
             //  RenderBuffer rb = tex.colorBuffer;
           //     Debug.Log(rb);
                //Debug.Log(hits[i].collider.GetComponent<Shader>);
                Debug.Log(tempColor.r + "," + tempColor.g + "," + tempColor.b);
                Texture2D texture2D = rend.material.mainTexture as Texture2D;
                Vector2 pCoord = hits[i].textureCoord;
                pCoord.x *= texture2D.width;
                pCoord.y *= texture2D.height;

                Vector2 tiling = rend.material.mainTextureScale;
      
                rend.material.color = tempColor;

           

            }

  
        }
        return false;
    }
    private void Boost()
    {
        Vector3 vel = tr.up * v_direction * Time.fixedTime * moveSpeed;
        tr.position = tr.position + vel;

    }

    private void MoveBetter()
    {

    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        rb.velocity = new Vector2(x, y);

    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }

    private void Drag()
    {
        Vector2 dragDir = -(Vector2.zero - new Vector2(tr.position.x, tr.position.y));
        tr.position = Move3D2D(tr.position, dragDir * Time.fixedTime * dragSpeed);
    }

    private Vector3 Move3D2D(Vector3 vec3, Vector2 vec2)
    {
        return new Vector3(vec3.x + vec2.x, vec3.y + vec2.y, vec3.z);
    }
}


