using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    [SerializeField,Range(0,10000)] private int _expAmount;
    private DropController _dropController;
    private void Start()
    {
        _dropController = FindFirstObjectByType<DropController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ILevelUp levelUp))
        {
            levelUp.AddExp(_expAmount);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        _dropController.SpawnedDrop.Remove(gameObject);
    }
}
