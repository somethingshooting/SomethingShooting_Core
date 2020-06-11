using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_MoveStraight : EnemyBehaviour
{
    [SerializeField] private float _ShootInterval = 1.0f;
    [SerializeField] private GameObject _ShootBulletObject = null;

    [SerializeField] private float _MoveSpeed = 1.5f;

    private float _InstantateTimer = 0.0f;

    protected override void Init()
    {
        if (_ShootBulletObject == null)
        {
            Debug.LogError("弾がアタッチされていません");
        }
    }

    void Update()
    {
        _InstantateTimer += Time.deltaTime;
        if (_InstantateTimer >= _ShootInterval)
        {
            _InstantateTimer = 0.0f;

            var bullet = Instantiate(_ShootBulletObject);
            bullet.transform.position = this.transform.position;
        }

        transform.Translate(Vector3.forward * _MoveSpeed * Time.deltaTime);
    }
}
