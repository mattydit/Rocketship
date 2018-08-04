using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingRoad : MonoBehaviour
{
    private float planeLength;
    private BoxCollider planeCollider;

	// Use this for initialization
	void Start ()
    {
        planeCollider = GetComponent<BoxCollider>();
        planeLength = planeCollider.size.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (transform.position.z < -planeLength)
        {
            RepositionPlane();
        }
	}

    private void RepositionPlane()
    {
        Vector3 planeOffset = new Vector3(0, 0, planeLength * 3.5f);
        transform.position = (Vector3)transform.position + planeOffset;
    }
}
