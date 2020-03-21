using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour, IBullet
{
    public Parameter MoveSpeed = new Parameter(1);

    public Parameter ATK = new Parameter(1);

    public SkillAttributeType AttributeType;

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (gameObject.tag == "EnemyBullet")
                {
                    other.GetComponent<IHitPointObject>()
                        .GetDamage(ATK.Value, AttributeType);
                }
                break;
            case "Enemy":
                if (gameObject.tag == "PlayerBullet")
                {
                    other.GetComponent<IHitPointObject>()
                        .GetDamage(ATK.Value, AttributeType);
                }
                break;
            default:
                break;
        }
    }
}
