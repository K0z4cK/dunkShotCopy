using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : SingletonComponent<Ball>
{
    [SerializeField]
    BallWorldUI ballWorldUI;

    [SerializeField]
    AudioSource audioSource;

    public int BOUNCE_COUNT { get; private set; }
    public int WALL_BOUNCE_COUNT { get; private set; }

    private Rigidbody2D ballRigidbody;

    void Awake()
    {
        ballWorldUI = this.GetComponentInChildren<BallWorldUI>();

        audioSource = this.GetComponent<AudioSource>();

        ballRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

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
        audioSource.Play();
        if(PlayerPrefs.GetInt("VibrationOn") == 1)
            Handheld.Vibrate();
    }
    public void ShowTexts()
    {
        //ballWorldUI.Show();
    }
    private void ClearCounters()
    {
        BOUNCE_COUNT = 0;
        WALL_BOUNCE_COUNT = 0;
    }

    private void Update()
    {
        if (ballRigidbody.IsSleeping() && ballRigidbody.simulated)
        {
            Vector2 sideForce = new Vector2();
            if (transform.position.x > 0)
                sideForce = Vector2.left * 200;
            else
                sideForce = Vector2.right * 200;

            Vector2 force = sideForce + (Vector2.up * 700f);

            ballRigidbody.AddForce(force);
            print("aded force: " + force);
        }

    }
}
