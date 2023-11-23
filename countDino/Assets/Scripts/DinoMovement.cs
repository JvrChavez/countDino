using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public float velocidad = 200.0f; // Velocidad de movimiento del sprite
    private Rigidbody2D rb;
    private bool right = true;
    private SpriteRenderer spriteRenderer;
    private Vector3 posInicial;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent <SpriteRenderer>();
        posInicial = Camera.main.WorldToScreenPoint(transform.position);
    }
    void Update()
    {
        rb.velocity = right ? new Vector2(velocidad, rb.velocity.y) : new Vector2(-velocidad, rb.velocity.y);
        Vector3 pantallaPos = Camera.main.WorldToScreenPoint(transform.position);
        if (pantallaPos.x < posInicial.x)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        right = false;      
        spriteRenderer.flipX = true;
    }
}