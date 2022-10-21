using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed;
    public float upDownSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        MovePipe();
        InvokeRepeating("SwitchUpDown", 0.1f, 1);
    }



    public void MovePipe()
    {
        rb.velocity = new Vector2(-speed, upDownSpeed);
    }

    public void SwitchUpDown()
    {
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2(speed, upDownSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.CompareTag("pipeRemover"))
        {
            Destroy(gameObject);
        }
    }
}
