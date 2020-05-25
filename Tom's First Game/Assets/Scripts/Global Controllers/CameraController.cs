using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0,0,-1);
    

    // Update is called once per frame
    void FixedUpdate(){
        transform.position = player.transform.position + offset;
    }
}
