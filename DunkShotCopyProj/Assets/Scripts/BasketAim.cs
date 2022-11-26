using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketAim : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public Vector2 launchPosition;
    public GameObject ball;
    

    private Rigidbody2D ballRigidbody;   
    private Collider2D bottomBound;
    public float velocityMult = 8f;

    [SerializeField]
    private TrajectoryLine trajectory;

    public Collider2D catcher;

    private bool _aimingMode;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        trajectory = GetComponent<TrajectoryLine>();
        launchPosition = transform.position;
        bottomBound = transform.parent.GetComponent<Collider2D>();
        _aimingMode = false;
    }
    private void OnMouseDown()
    {
        if (ball == null)
            return;
        // this.transform.up = Vector3.zero;
        bottomBound.enabled = false;
        catcher.enabled = false;
        //this.GetComponent<Collider2D>().enabled = true;
        _aimingMode = true;
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballRigidbody.isKinematic = true;
        ballRigidbody.simulated = true;
        if (GameManager.Instance.SCORE == 0)
            EventManager.Instance.GameStarted();
        print("aim");
    }


    void RotateBasket(Vector2 mousePos)
    {
        Vector2 direction = mousePos - new Vector2(transform.position.x, transform.position.y);

        transform.parent.transform.up = direction*-1;
    }
    void Update()
    {
        if (!_aimingMode)
            return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateBasket(mousePosition);
        Vector2 mouseDelta = mousePosition - launchPosition;        
        float maxMagnitude = this.GetComponent<CircleCollider2D>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        Vector2 ballPos = (launchPosition + mouseDelta);
        ball.transform.position = ballPos;
        trajectory.ShowTrajectoryLine(launchPosition, -mouseDelta * (velocityMult*1.5f));
        if(Input.GetMouseButtonUp(0) )
        {
            if ((-mouseDelta * velocityMult * 1.5f).x > 6f || (-mouseDelta * velocityMult * 1.5f).y > 6f)
            {
                print("shot");
                _aimingMode = false;
                ballRigidbody.isKinematic = false;
                ballRigidbody.velocity = -mouseDelta * velocityMult * 1.5f;
                print("velocity: " + ballRigidbody.velocity);
                trajectory.ClearTrajectory();
                ball = null;
                EventManager.Instance.BallShoted();
                audioSource.Play();
            }
            else {
                trajectory.ClearTrajectory();
                _aimingMode = !_aimingMode;
                bottomBound.enabled = true;
                catcher.enabled = true;
                ballRigidbody.isKinematic = false;
                ballRigidbody.simulated = false;
                ball.transform.position = this.transform.position;
                transform.parent.transform.up = Vector3.up;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bottomBound.enabled = true;
        catcher.enabled = true;
        transform.parent.transform.up = Vector3.up;
        //ball = null;
    }
}
