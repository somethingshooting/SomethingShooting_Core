using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour, IBullet, IPoolingObject
{
    public float MoveSpeed = 1.0f;

    public int ATK = 1;

    public SkillAttributeType AttributeType;
    protected PoolingController _PoolingController;

    protected virtual void Start()
    {
        Init();
    }

    public void PoolingStart()
    {
        Init();
    }

    protected abstract void Init();

    public virtual void DestroyBullet()
    {
        _PoolingController.Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if ((gameObject.tag == "PlayerBullet" && other.tag == "Enemy") || (gameObject.tag == "EnemyBullet" && other.tag == "Player"))
        {
            other.GetComponent<IHitPointObject>()
                        .GetDamage(ATK, AttributeType);
        }
    }
}
