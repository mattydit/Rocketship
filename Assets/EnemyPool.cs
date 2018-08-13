using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public int enemyPoolSize = 5;
    private GameObject[] enemies;
    public GameObject enemyPrefab;
    private Vector3 objectPoolPos = new Vector3(0, 0.6f, -11.5f);
    private float timeSinceLast;
    public float spawnRate = 4f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
