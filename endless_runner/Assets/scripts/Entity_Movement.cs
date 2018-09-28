using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Movement : MonoBehaviour {
    [SerializeField] private float speed = 8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < -13) Destroy(gameObject);
	}
}
