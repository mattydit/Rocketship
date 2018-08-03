﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Rigidbody rb;
    private float xPos;
    private float drift = 20;
    

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        xPos = rb.position.x;
	}

    private void FixedUpdate()
    {
        

    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 pos = rb.position;
        pos.x = Mathf.MoveTowards(pos.x, xPos, drift * Time.deltaTime);
        rb.position = pos;

        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (xPos <= -3)
            {
                xPos = -3;
            }
            else
            {
                xPos -= 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (xPos >= 3)
            {
                xPos = 3;
            }
            else
            {
                xPos += 3;
            }
        }

        rb.AddForce(transform.forward * drift * Time.deltaTime, ForceMode.Acceleration);
	}

    void Fire()
    {
        

        //Create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        //Add velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 1.55f);
    }
}