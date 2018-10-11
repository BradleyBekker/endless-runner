using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Movement : MonoBehaviour {

    
    [SerializeField] private float speed = 8;

	
	void Update () {
        // moves things to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < -13) Destroy(gameObject);
	}
}
