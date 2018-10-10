using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    public List<GameObject> entities = new List<GameObject>();

    [SerializeField] private GameObject player;
        //0 = hostile bird, 1 = coins, 2 = shield
    private float timer =  0;
    private float spawntime = 75;
	
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
            Instantiate(entities[0], new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);
            if (player.GetComponent<Player_Movement>().GetScore() >= 60) Instantiate(entities[0], new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);
            if (player.GetComponent<Player_Movement>().GetScore() >= 130) Instantiate(entities[0], new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);
            //spawns coins
            if (Random.Range(0,2) == 1)Instantiate(entities[1], new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);

            //spawns shields
            if (Random.Range(0, 10) == 1) Instantiate(entities[2], new Vector3(10, Random.Range(-3.5f, 5), 0), Quaternion.identity);


            timer = 0;
        }
    }
}
