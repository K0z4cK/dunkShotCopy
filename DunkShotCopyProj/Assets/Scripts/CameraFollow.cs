using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D bottomBorder;
    public Transform ball;
    private bool _follow;
    private void Awake()
    {
        _follow = true;

        leftWall.size = new Vector2(1f, Camera.main.ScreenToWorldPoint( new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(Camera.main.ScreenToWorldPoint(Vector3.zero).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f,0f)).x + 0.5f, 0f);

        bottomBorder.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomBorder.offset = new Vector2(0f, Camera.main.ScreenToWorldPoint(Vector3.zero).y - 0.5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x-3, transform.position.y / 3f, transform.position.z+10), transform.position);

    }
    private void Update()
    {
        if(ball.position.y > transform.position.y/3 && _follow)
            transform.position = new Vector3(transform.position.x, ball.position.y, transform.position.z);
    }
}
