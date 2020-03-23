using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BulletBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed.Value);
    }
}
