using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttackObject : MonoBehaviour
{
    public int Damage;
    public ObjectType type;

    public void OnTriggerEnter(Collider other)
    {
        HurtObject hurt = other.GetComponent<HurtObject>();
        if (hurt != null)
        {
            if (hurt.type != type)
            {
                hurt.GetDamage(Damage);
            }
        }
    }
}
