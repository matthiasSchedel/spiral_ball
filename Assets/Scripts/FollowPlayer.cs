using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, -6, 0);
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.Find("Player");
        //if (player != null)
        //{
        //    if (playerTransform != null)
        //    {
        //        playerTransform = player.transform;
        //        transform.position = playerTransform.position + offset;
        //    }
        //}
        //else {
        //    Debug.Log("else");
        //}
    }

    public void SetTransform(Transform trafo)
    {
        playerTransform = trafo;
        transform.position = playerTransform.position + offset;
    }


    void Update()
    {
        //GameObject player = GameObject.Find("Player");
        //if (player != null) {
        //    if (playerTransform != null) {
        //        playerTransform = player.transform;
        //        transform.position = playerTransform.position + offset;
        //    }
        //}
        //else
        //{
        //    Debug.Log("else");
        //}
        if (playerTransform != null)
        {
            Vector3 pos = playerTransform.position + offset;
            transform.position = new Vector3(pos.x, pos.y, -10);
        }
  
    }
}
