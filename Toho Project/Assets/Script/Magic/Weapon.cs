using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _destroyTime;
    [SerializeField] private bool _destroyOnEnterCol;
    [SerializeField] private float _critMulti;
    [SerializeField] private float _critChance;

    float totalDamage;
    private void FixedUpdate()
    {
        Destroy(gameObject, _destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            int rnd = Random.Range(0, 100);
            if (rnd <= _critChance)
            {
                totalDamage = _damage * _critMulti;
            }
            else
            {
                totalDamage = _damage;
            }
            damageable.TakeDamage(totalDamage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            int rnd = Random.Range(0, 100);
            if (rnd <= _critChance)
            {
                totalDamage = _damage * _critMulti;
            }
            else
            {
                totalDamage = _damage;
            }
            damageable.TakeDamage(totalDamage);
        }
        if (_destroyOnEnterCol)
        {
            Destroy(this.gameObject);
        }
    }
}
