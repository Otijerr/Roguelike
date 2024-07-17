using UnityEngine;

public class HealingDrop : MonoBehaviour
{
    [SerializeField,Range(0,100)] private int _healAmount;
    private DropController _dropController;

    private void Start()
    {
        _dropController = FindFirstObjectByType<DropController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealable healable))
        {
            healable.ChangedHealth(_healAmount);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        _dropController.SpawnedDrop.Remove(gameObject);
    }
}
