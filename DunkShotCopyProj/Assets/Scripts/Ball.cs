using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : SingletonComponent<Ball>
{
    public int BOUNCE_COUNT { get; private set; }
    public int WALL_BOUNCE_COUNT { get; private set; }

    void Awake()
    {
        BOUNCE_COUNT = 0;
        WALL_BOUNCE_COUNT = 0;
        EventManager.Instance.ballShot.AddListener(ClearCounters);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("ball wall");
            WALL_BOUNCE_COUNT++;
        }
        else
            BOUNCE_COUNT++;    
    }

    private void ClearCounters()
    {
        BOUNCE_COUNT = 0;
        WALL_BOUNCE_COUNT = 0;
    }
}
