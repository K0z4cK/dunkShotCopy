using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketAim : MonoBehaviour
{
    public Vector2 launchPosition;
    public GameObject ball;
    

    private Rigidbody2D ballRigidbody;   
    private Collider2D bottomBound;
    public float velocityMult = 8f;

    [SerializeField]
    private TrajectoryLine trajectory;

    //temp (replace with actions in future)
    public Collider2D catcher;

    private bool _aimingMode;
    void Awake()
    {
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
        this.GetComponent<Collider2D>().enabled = true;
        _aimingMode = true;
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballRigidbody.isKinematic = true;
        ballRigidbody.simulated = true;
        
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
        trajectory.ShowTrajectoryLine(launchPosition, -mouseDelta * velocityMult*2);
        if(Input.GetMouseButtonUp(0))
        {
            print("shot");
            _aimingMode = false;          
            ballRigidbody.isKinematic = false;
            ballRigidbody.velocity = -mouseDelta * velocityMult*2;
            //print("velocity: " + ballRigidbody.velocity);
            trajectory.ClearTrajectory();
            ball = null;
            EventManager.Instance.BallShoted();
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
