using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        //Start moving the object
        rb.velocity = new Vector3(0, 0, GameControl.instance.scrollspeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Stop when game over
        if (GameControl.instance.game_over == true)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
