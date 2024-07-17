using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float MaxHp;
    [SerializeField] protected int Damage;
    [SerializeField] protected float AttackCD;

    [SerializeField] protected Rigidbody2D Rb2D;

    protected DamageTextManager DmgTextManager;
    protected Transform PlayerTransform;
    [SerializeField] protected EnemyDrop EneDrop;
    [SerializeField] protected EnemyManager EnemyManager;

    protected float CurrentHp;
    protected float CurrentCD;
    private void Start()
    {
        CurrentHp = MaxHp;
        PlayerTransform = FindFirstObjectByType<PlayerController>().transform;
        DmgTextManager = FindFirstObjectByType<DamageTextManager>();
        EnemyManager = FindFirstObjectByType<EnemyManager>();
    }
    private void OnDestroy()
    {
        EnemyManager.RemoveEnemyFromList(gameObject);
    }
    public void TakeDamage(float damage)
    {
        DmgTextManager.ShowDamageText(damage, transform.position);
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            EneDrop.SpawnDrop();
            Destroy(gameObject);
        }
    }
}
