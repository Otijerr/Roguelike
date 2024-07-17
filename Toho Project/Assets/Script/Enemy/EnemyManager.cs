using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Vector2 spawnArea;
    [SerializeField] private float spawnRate;
    private float spawnTime;
    private Transform _player;

    [SerializeField] private List<Enemies> _startEnemies;
    [SerializeField] private List<Enemies> _midEnemies;
    [SerializeField] private List<Enemies> _endEnemies;
    private List<Enemies> _enemies;

    [Header("Optimization")]
    private List<GameObject> _spawnedEnemy = new List<GameObject>();
    [SerializeField] private float _maxOpDist;
    float opDist;
    [SerializeField] private float optimizerCoolDownDir;
    private void Awake()
    {
        spawnTime = spawnRate;
        _player = FindFirstObjectByType<PlayerController>().transform;
        _enemies = _startEnemies;
        StartCoroutine(Spawner());
    }

    private void SpawnEnemy()
    {
        foreach (Enemies ene in _enemies)
        {
            int rnd = Random.Range(0, 100);
            if (rnd <= ene.chance)
            {
                Vector3 spawnPosition = GenerateRndPos();
                spawnPosition += _player.position;
                _spawnedEnemy.Add(Instantiate(ene.enemy,spawnPosition,Quaternion.identity));
                break;
            }
        }
    }

    private Vector3 GenerateRndPos()
    {
        Vector3 pos = new Vector3();
        float f = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f)
        {
            pos.x = Random.Range(-spawnArea.x, spawnArea.x);
            pos.y = spawnArea.y * f;
        }
        else
        {
            pos.y = Random.Range(-spawnArea.y,spawnArea.y);
            pos.x = spawnArea.x * f;
        }
        pos.z = 0;
            return pos;
    }
    public void RemoveEnemyFromList(GameObject enemy)
    {
        _spawnedEnemy.Remove(enemy);
    }
    void EnemyOptimizer()
    {
        foreach (GameObject enemy in _spawnedEnemy)
        {
            opDist = Vector3.Distance(_player.position, enemy.transform.position);
            if (opDist > _maxOpDist)
            {
                enemy.SetActive(false);
            }
            else if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
            }
        }
    }
    public Vector3 FindNearestEnemy(Transform objTransform)
    {
        float closestDistance = float.MaxValue;
        Transform _enemy = null;
        foreach (GameObject enemy in _spawnedEnemy)
        {
            float distance = Vector2.Distance(objTransform.position, enemy.gameObject.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                _enemy = enemy.transform;
            }
        }
        Vector3 dir = (_enemy.transform.position - objTransform.position).normalized;
        return dir;
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            spawnTime = spawnRate - (Time.time / 600);
            yield return new WaitForSeconds(spawnTime);
            SpawnEnemy();
            EnemyOptimizer();
        }
    }
}
[System.Serializable]
public class Enemies
{
    public GameObject enemy;
    public float chance;
}

