using System;
using System.Collections;
using Player;
using UnityEngine;
using Object = System.Object;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _turretBullet;
    [SerializeField] private Transform _turretBulletSpawnPoint;
    [SerializeField] private float _turretBulletSpeed;
    Coroutine _turretBulletCoroutine;
    WaitForSeconds _shootingDelay = new(5f);

    private void Awake()
    {
        _turretBulletCoroutine = StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            yield return _shootingDelay;
            var bullet = Instantiate(_turretBullet, _turretBulletSpawnPoint.position, _turretBulletSpawnPoint.rotation);
            var rb = bullet.GetComponent<Rigidbody2D>();
            float scaleSign = Mathf.Sign(transform.localScale.x);
            rb.linearVelocity = new Vector2(scaleSign * _turretBulletSpeed, 0f);
        } 
    }

    private void OnDisable()
    {
        StopCoroutine(_turretBulletCoroutine);
    }
}
