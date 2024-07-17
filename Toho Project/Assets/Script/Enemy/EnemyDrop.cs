using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private List<Drops> _drops;
    private DropController _dropController;
    private void Start()
    {
        _dropController = FindFirstObjectByType<DropController>();
    }
    public void SpawnDrop()
    {
        int rnd = Random.Range(0, 100);
        foreach (Drops drop in _drops)
        {
            if(rnd <= drop.Chance)
            {
                _dropController.SpawnedDrop.Add(Instantiate(drop.Drop,transform.position,Quaternion.identity));
                break;
            }
        }
    }
}
[System.Serializable]
public class Drops
{
    public GameObject Drop;
    public int Chance;
}
