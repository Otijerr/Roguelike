using System.Collections.Generic;

using UnityEngine;

public class ReimuUltimate : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private int _maxSize;
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float _speed;
    [SerializeField] private TrailRenderer _trail;

    private EnemyManager _enemyManager;
    private bool isTriggered = false;
    void Start()
    {
        int rnd = Random.Range(0, _colors.Length);
        _particle.startColor = _colors[rnd];
        _trail.startColor = _colors[rnd];
        _trail.endColor = _colors[rnd] + new Color(0, 0, 0, 255);
        _enemyManager = FindFirstObjectByType<EnemyManager>();
    }

    void Update()
    {
        if (!isTriggered)
        {
            _rb2D.velocity = _enemyManager.FindNearestEnemy(transform) * _speed;
        }
        else
        {
            transform.localScale -= new Vector3(1f, 1f, 0) * Time.deltaTime;
            if (transform.localScale.x <=0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable) && !isTriggered) 
        {
            transform.localScale = new Vector3(_maxSize,_maxSize,1);
            _rb2D.velocity = Vector2.zero;
            isTriggered = true;
        }
    }
}
