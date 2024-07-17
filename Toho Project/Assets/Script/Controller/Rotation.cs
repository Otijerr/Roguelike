using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;

    private Vector2 mousePos;
    public Vector2 spawnPos;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.position = rb2.position;
        Vector2 lookDir = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        spawnPos = rb.position + lookDir * 1.5f;
    }

}
