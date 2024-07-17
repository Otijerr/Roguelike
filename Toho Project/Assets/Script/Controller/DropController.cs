using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    private Transform _player;

    [Header("Optimization")]
    public List<GameObject> SpawnedDrop;
    [SerializeField] private float _maxOpDist;
    float opDist;
    float optimizerCoolDown;
    [SerializeField] private float optimizerCoolDownDir;

    private void Awake()
    {
        _player = FindFirstObjectByType<PlayerController>().transform;
    }
    private void Update()
    {
        DropOptimizer();
    }
    void DropOptimizer()
    {
        optimizerCoolDown -= Time.deltaTime;
        if (optimizerCoolDown <= 0f)
        {
            optimizerCoolDown = optimizerCoolDownDir;
        }
        else
        {
            return;
        }
        if (SpawnedDrop != null)
        {
            foreach (GameObject drop in SpawnedDrop)
            {
                opDist = Vector3.Distance(_player.position, drop.transform.position);
                if (opDist > _maxOpDist)
                {
                    drop.SetActive(false);
                }
                else if (drop.activeInHierarchy == false)
                {
                    drop.SetActive(true);
                }
            }
        }
    }
}
