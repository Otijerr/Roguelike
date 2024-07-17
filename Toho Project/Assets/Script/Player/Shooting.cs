using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _force;

    float timer = 0f;
    Vector2 spawnPos;

    void Update()
    {
        spawnPos = FindFirstObjectByType<Rotation>().spawnPos;
        if (Input.GetButton("Fire1") && timer <= 0)
        {
            Shoot();
            timer = _fireRate;
        }
        timer -= Time.deltaTime;
    }
    void Shoot()
    {
        Rigidbody2D rb = Instantiate(weapon, spawnPos, firePoint.rotation).GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * _force, ForceMode2D.Impulse);
    }
}
