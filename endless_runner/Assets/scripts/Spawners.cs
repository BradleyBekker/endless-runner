using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {
   [SerializeField] private GameObject bird;
   [SerializeField] private GameObject coin;
   private float timer =  0;
   private float spawntime = 75;

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


            Instantiate(bird, new Vector3(10, Random.Range(-5, 5), 0), Quaternion.identity);
            if(Random.Range(0,3) == 1)Instantiate(coin, new Vector3(10, Random.Range(-4.5f, 5), 0), Quaternion.identity);
            timer = 0;
            

        }
    }
}
