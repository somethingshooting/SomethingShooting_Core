using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour, IBullet
{
    public float MoveSpeed = 1.0f;

    public int ATK = 1;

    public SkillAttributeType AttributeType;

    public virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if ((gameObject.tag == "PlayerBullet" && other.tag == "Enemy") || (gameObject.tag == "EnemyBullet" && other.tag == "Player"))
        {
            other.GetComponent<IHitPointObject>()
                        .GetDamage(ATK.Value, AttributeType);
        }
    }
}
