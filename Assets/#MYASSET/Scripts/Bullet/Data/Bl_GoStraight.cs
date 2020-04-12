using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bl_GoStraight : BulletBehaviour
{

    private void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed);
    }

}
