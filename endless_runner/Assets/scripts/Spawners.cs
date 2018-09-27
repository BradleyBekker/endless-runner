using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {
   [SerializeField] GameObject prefab;
    float timer =  0;
    float spawntime = 75;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
	}

    void Spawn() {
        timer++;
        if (timer >= spawntime)
        {

            Vector3 spawn = new Vector3(10, Random.Range(-5,5), 0);

            Instantiate(prefab, spawn, Quaternion.identity);

            timer = 0;
        }
    }
}
