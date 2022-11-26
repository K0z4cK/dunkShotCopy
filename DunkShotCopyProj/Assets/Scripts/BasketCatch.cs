using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCatch : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public BasketAim aim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("colission");
        if (collision.tag == "ball")
        {
            aim.ball = collision.gameObject;
            aim.ball.transform.position = aim.transform.position;
            collision.GetComponent<Rigidbody2D>().simulated = false;

            /*if(CameraFollow.Instance.lowerPoint.position.y > this.transform.position.y+1.5f)
                EventManager.Instance.BallCatchedBack(this.transform.parent.gameObject);*/

            audioSource.Play();

            if (CameraFollow.Instance.lowerPoint != this.transform.parent ) 
                EventManager.Instance.BallCatched();

            print("ball in basekt");
        }
    }
    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
}
