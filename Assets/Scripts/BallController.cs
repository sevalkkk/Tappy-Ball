using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float upForce;
    Rigidbody2D rb;
    bool started;
    bool gameOver;
    public GameObject GameOverPanel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        started = false;
        gameOver = false;
    }

    private void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pipe")
        {
            gameOver = true;
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if(collision.gameObject.tag=="scoreChecker" && !gameOver)
        {
            ScoreManager.instance.IncrementScore();
        }
    }
}
