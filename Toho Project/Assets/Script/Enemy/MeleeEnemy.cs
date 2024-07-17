using UnityEngine;

public class MeleeEnemy : Enemy , IDamageable
{
    void FixedUpdate()
    {
        Vector3 dir = (PlayerTransform.position - transform.position).normalized;
        Rb2D.velocity = dir * Speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealable health))
        {
            CurrentCD -= Time.deltaTime;
            if (CurrentCD <= 0f)
            {
                health.ChangedHealth(-Damage);
                CurrentCD = AttackCD;
            }
        }
    }
}
