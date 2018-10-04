using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {
    
    [SerializeField]float score = 0;
    [SerializeField] Text scoretext;
    [SerializeField] GameObject shield;
    private float speed = 6;
    private bool crash = false;
    private bool controllable = true;
    private bool shielded = false;
    
    // Use this for initialization
    void Start () {
        shield.SetActive(false);        
    }
	
	// Update is called once per frame
	void Update () {

        score=score + 0.01f;
        PosCheck();
        scoretext.text = "score: " + score.ToString("f0");
        if (controllable && Input.GetKey(KeyCode.W)) transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        if (controllable && Input.GetKey(KeyCode.S)) transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        if (crash) {
            controllable = false;
            transform.Rotate(new Vector3 (0,0,1),-30);
            transform.Translate(new Vector2(2, -2) * 4 * Time.deltaTime, Space.World);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hostile")
        {
            if (shielded)
            {
                Destroy(collision.gameObject);
                shielded = false;
                shield.SetActive(false);

            }
            else
            {

                crash = true;
                StartCoroutine(Restart());
            }
        }
        if (collision.gameObject.tag == "coin")
        {
            score = score + 10;
            Destroy(collision.gameObject);

        }
        
        if (collision.gameObject.tag == "shield")
        {
            shielded = true;
            shield.SetActive(true);
            Destroy(collision.gameObject);

        }

    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene(1);

    }
    public float GetScore()
    {
        return score;
    }
    private void PosCheck()
    {
        if (!crash) {
            if (transform.position.y < -3.3f)
            {
                print("bottom barrier");
                transform.position = new Vector2(transform.position.x, -3.31f);
            }
            if (transform.position.y > 5.3f)
            {
                transform.position = new Vector2(transform.position.x, 5.31f);
            }
        }
    }



}
