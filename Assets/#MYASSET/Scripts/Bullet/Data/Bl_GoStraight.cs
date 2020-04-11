using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bl_GoStraight : BulletBehaviour
{
    [SerializeField]
    private float _Speed = 1;

    private void Update()
    {
        transform.position += Vector3.forward * _Speed;
    }

}
