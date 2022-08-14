using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        this.transform.Translate(0, 0, 0.1f);
    }
}
