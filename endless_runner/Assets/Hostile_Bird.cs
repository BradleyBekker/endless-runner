using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * 8 * Time.deltaTime, Space.World);

        if (transform.position.x < -13) Destroy(gameObject);
	}
}
