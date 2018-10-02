using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {
    
    [SerializeField]float score = 0;
    [SerializeField] Text scoretext;
    private bool crash = false;
    private bool controllable = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score=score + 0.01f;
        scoretext.text = "score: " + score.ToString("f0");
        if (controllable && Input.GetKey(KeyCode.W)) transform.Translate(Vector3.up * 4 * Time.deltaTime, Space.World);
        if (controllable && Input.GetKey(KeyCode.S)) transform.Translate(Vector3.down * 4 * Time.deltaTime, Space.World);

        if (crash) {
            controllable = false;
            transform.Translate(new Vector2(2, -2) * 4 * Time.deltaTime, Space.World);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hostile")
        {
            crash = true;
            StartCoroutine(Wait());
        }
        if (collision.gameObject.tag == "coin")
        {
            score = score + 10;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "barrierbottom")
        {
            print("bottom barrier");
            transform.position = new Vector2(transform.position.x,-3.31f);
        }
        if (collision.gameObject.tag == "barriertop")
        {
            transform.position = new Vector2(transform.position.x, 5.31f);
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene(1);

    }
    public float GetScore()
    {
        return score;
    }



}
