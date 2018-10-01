using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerOnContact : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        //Explosion
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);

        //End game
        GameControl.instance.PlayerDied();
    }
}
