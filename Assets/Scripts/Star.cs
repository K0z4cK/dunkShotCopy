using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("star colission");
        if (collision.gameObject.tag == "ball")
        {
            EventManager.Instance.StarCatched();
            Destroy(this.gameObject);
        }
    }
}
