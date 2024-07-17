using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshPro textComponent;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float fadeSpeed = 2.0f;

    private float alpha = 1.0f;

    void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        alpha -= fadeSpeed * Time.deltaTime;
    }
    public void SetDamage(float damage)
    {
        textComponent.text = damage.ToString();
    }
}
