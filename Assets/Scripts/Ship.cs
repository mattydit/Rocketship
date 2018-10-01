using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private bool isDead = false;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Rigidbody rb;
    private float xPos;
    private float drift = 20;
    private int ammo = 3;
    

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

        if (isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Fire();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //Boundary left
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
                //Boundary right
                if (xPos >= 3)
                {
                    xPos = 3;
                }
                else
                {
                    xPos += 3;
                }
            }

            //Move the ship
            rb.AddForce(transform.forward * drift * Time.deltaTime, ForceMode.Acceleration);
        }
    }
       

    void Fire()
    {
        ammo--;

        //Create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        //Add velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);

        if (ammo <= 0)
        {
            Reload();
        }

    }

    void Reload()
    {

    }

    void OnCollisionEnter()
    {
        isDead = true;
        GameControl.instance.PlayerDied();

    }
}
