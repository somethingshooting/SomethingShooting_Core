using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bl_GoStraight : BulletBehaviour
{
    [SerializeField]
    private float _LastTime = 10;
    private void Start()
    {
        Destroy(gameObject, _LastTime);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed*Time.deltaTime);
    }

}
