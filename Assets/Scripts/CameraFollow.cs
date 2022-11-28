using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : SingletonComponent<CameraFollow>
{
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D bottomBorder;
    public Transform ball;
    public Transform lowerPoint;

    private bool _follow;
    private void Awake()
    {
        _follow = true;

        leftWall.size = new Vector2(1f, Camera.main.ScreenToWorldPoint( new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(Camera.main.ScreenToWorldPoint(Vector3.zero).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f,0f)).x + 0.5f, 0f);

        bottomBorder.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomBorder.offset = new Vector2(0f, Camera.main.ScreenToWorldPoint(Vector3.zero).y - 5.5f);

        EventManager.Instance.basketUpdate.AddListener(UpdateLoverPoint);
    }
    private void UpdateLoverPoint(Transform newLowerPoint)
    {
        lowerPoint = newLowerPoint;
        transform.position = new Vector3(transform.position.x, lowerPoint.position.y + 1.5f, transform.position.z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(lowerPoint.position.x, lowerPoint.position.y +1f, lowerPoint.position.z), transform.position);

    }
    private void Update()
    {
        if(ball.position.y > lowerPoint.position.y+1.5f && _follow)
            transform.position = new Vector3(transform.position.x, ball.position.y+1.5f, transform.position.z);
    }
}
