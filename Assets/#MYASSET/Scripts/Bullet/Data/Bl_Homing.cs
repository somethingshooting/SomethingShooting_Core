using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bl_Homing : BulletBehaviour
{
    [SerializeField]private float _LastTime = 10;
    private Transform _Enemypos;
    private bool _IsHoming = false;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, _LastTime);
        if (gameObject.tag == "PlayerBullet")
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            float d = 0;
            int nom = 0;
            if (enemys.Length != 0)
            {
                d = Vector3.Distance(transform.position, enemys[0].transform.position);
                for (int i = 0; i < enemys.Length; i++)
                {
                    float newD = Vector3.Distance(transform.position, enemys[i].transform.position);
                    if (d > newD)
                    {
                        d = newD;
                        nom = i;
                    }
                }
                _Enemypos = enemys[nom].transform;
                _IsHoming = true;
            }
        }else if(gameObject.tag == "EnemyBullet")
        {
            _Enemypos = PlayerManager.Instance.transform;
            _IsHoming = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_IsHoming)
        {
            if (_Enemypos != null)
            {
                transform.LookAt(_Enemypos);
            }
            else
            {
                _IsHoming = false;
            }


        }

        transform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
    }
}
