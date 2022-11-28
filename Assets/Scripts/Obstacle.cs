using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Awake()
    {
        EventManager.Instance.ballCatch.AddListener(Destroy);
    }

    private void Destroy()
    {
        if (this.transform.parent == CameraFollow.Instance.lowerPoint)
            Destroy(this.gameObject);
    }
}
