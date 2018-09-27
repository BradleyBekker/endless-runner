using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {
    [SerializeField]float Speed;
    bool crash = false;
    bool controllable = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (controllable && Input.GetKey(KeyCode.W)) transform.Translate(Vector3.up * 4 * Time.deltaTime, Space.World);
        if (controllable && Input.GetKey(KeyCode.S)) transform.Translate(Vector3.down * 4 * Time.deltaTime, Space.World);

        if (crash) {
            controllable = false;
            transform.Translate(new Vector2(2, -2) * 4 * Time.deltaTime, Space.World);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("COLLISION");
        if (collision.gameObject.tag == "hostile")
        {
            crash = true;
            StartCoroutine(Wait());
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene(1);

    }


}
