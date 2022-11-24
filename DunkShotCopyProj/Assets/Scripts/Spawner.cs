using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject basket;


    MeshCollider spawpArea;

    void Start()
    {
        spawpArea = this.GetComponent<MeshCollider>();
        spawpArea.gameObject.transform.localScale = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.2f, 0f, 0f)).x, 2.5f);
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

    void Spawn()
    {
        float screenX, screenY;
        Vector2 pos;
        screenX = Random.Range(spawpArea.bounds.min.x, spawpArea.bounds.max.x);
        screenY = Random.Range(spawpArea.bounds.min.y, spawpArea.bounds.max.y);
        pos = new Vector2(screenX, screenY);

        GameObject newBasket = Instantiate(basket, pos, basket.transform.rotation);
        EventManager.Instance.OnBasketCreate(newBasket);
    }

}
