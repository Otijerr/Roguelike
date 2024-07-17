using UnityEngine;

public class UltimateSkill : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject _skill;

    void Update()
    {
        if (Input.GetButtonDown("e"))
        {
            Ultimate();
        }
    }

    void Ultimate()
    {
        Rigidbody2D rb = Instantiate(_skill, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up , ForceMode2D.Impulse);
    }
}
