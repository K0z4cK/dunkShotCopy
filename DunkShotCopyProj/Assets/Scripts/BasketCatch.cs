using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCatch : MonoBehaviour
{
    public BasketAim aim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("colission");
        if (collision.tag == "ball")
        {
            aim.ball = collision.gameObject;
            aim.ball.transform.position = aim.transform.position;
            if (collision.GetComponent<Rigidbody2D>().simulated = false);
            
            print("ball in basekt");
        }
    }
    void Update()
    {
        
    }
}
