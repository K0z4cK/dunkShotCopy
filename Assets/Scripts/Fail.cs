using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="ball")
        {
            //TEMP
            //Destroy(collision.gameObject);
            EventManager.Instance.GameOvered();
        }
    }
}
