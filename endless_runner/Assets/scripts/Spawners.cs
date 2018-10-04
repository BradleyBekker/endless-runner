using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {
   [SerializeField] private GameObject bird;
   [SerializeField] private GameObject coin;
   [SerializeField] private GameObject player;
    [SerializeField] private GameObject shield;

    private float timer =  0;
   private float spawntime = 75;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<Player_Movement>().GetScore() >= 30) spawntime = 45.5f; 

        Spawn();


	}

    void Spawn() {
        timer++;
        if (timer >= spawntime)
        {

            //spawns birds
            Instantiate(bird, new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);
            if (player.GetComponent<Player_Movement>().GetScore() >= 60) Instantiate(bird, new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);
            if (player.GetComponent<Player_Movement>().GetScore() >= 130) Instantiate(bird, new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);
            //spawns coins
            if (Random.Range(0,2) == 1)Instantiate(coin, new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);

            //spawns shields
            if (Random.Range(0, 10) == 1) Instantiate(shield, new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);


            timer = 0;
        }
    }
}
