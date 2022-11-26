using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject basket;
    [SerializeField]
    GameObject star;
    MeshCollider spawpArea;

    private float _screenX, _screenY;

    void Start()
    {
        spawpArea = this.GetComponent<MeshCollider>();
        spawpArea.gameObject.transform.localScale = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.2f, 0f, 0f)).x, 2f);
        EventManager.Instance.ballCatch.AddListener(Spawn);
    }

    //TEMP (TODO: change with game manager)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            Spawn();
        }
    }
    void SetBounds()
    {
        if(CameraFollow.Instance.lowerPoint.position.x < 0)
            _screenX = Random.Range(spawpArea.bounds.min.x, -1f);
        else
            _screenX = Random.Range(1f, spawpArea.bounds.max.x);

        _screenY = Random.Range(spawpArea.bounds.min.y, spawpArea.bounds.max.y);
    }
    void Spawn()
    {
        SetBounds();
        GameObject newBasket = Instantiate(basket, new Vector2(_screenX, _screenY), basket.transform.rotation);
        if(Random.Range(0,100) > 90)
        {
            Instantiate(star, new Vector2(_screenX, _screenY+1), star.transform.rotation);
        }
        EventManager.Instance.OnBasketCreate(newBasket);
    }

}
