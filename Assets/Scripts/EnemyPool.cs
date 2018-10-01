using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyPool : MonoBehaviour
{
    public int enemyPoolSize;
    public GameObject hazard;
    public GameObject hazard2;
    private Vector3 objectPoolPos = new Vector3(0, 0.6f, -11.5f);
    private float timeSinceLast;
    public float spawnRate;
    private int[] lanes = { -3, 0, 3 };
    private int current;
    int randomIndex;
    public float startWait;
    public float waveWait;

    List<GameObject> prefabList = new List<GameObject>();
    

	// Use this for initialization
	void Start ()
    {
        prefabList.Add(hazard);
        prefabList.Add(hazard2);
        StartCoroutine(SpawnObstacle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(startWait);
        while (GameControl.instance.game_over == false)
        {
            for(int i = 0; i <enemyPoolSize; i++)
            {
                int prefabIndex = UnityEngine.Random.Range(0, 2);

                System.Random r = new System.Random();
                //Create random index value
                randomIndex = r.Next(0, lanes.Length);
                //Use the random index value to pick a lane from the lanes array.
                int randomLane = lanes[randomIndex];
                Vector3 spawnPos = new Vector3(randomLane, 0.9f, -9f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(prefabList[prefabIndex], spawnPos, spawnRotation);
                yield return new WaitForSeconds(spawnRate);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }
}
