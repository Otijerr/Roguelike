using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinYang : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _empty;
    public float distance = 2.0f;
    public float rotationSpeed = 30.0f;

    private void Start()
    {
        if (_player == null)
        {
            _player = FindFirstObjectByType<PlayerController>().gameObject;
        }
        _empty = FindFirstObjectByType<Test>().gameObject.transform;
    }

    private void Update()
    {
        DistributeObjectsAroundPlayer();
        transform.Rotate(0, 0, 5);
    }

    private void DistributeObjectsAroundPlayer()
    {
        int childCount = _empty.transform.childCount;
        float angleIncrement = 360.0f / childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = _empty.transform.GetChild(i);
            Vector3 offset = Quaternion.Euler(0, 0, (angleIncrement * i) + rotationSpeed * Time.time) * Vector3.right * distance;

            Vector3 newPosition = _player.transform.position + offset;
            child.position = newPosition;
        }
    }
}


