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
    // Llamado al inicio
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent <SpriteRenderer>();
        posInicial = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Llamado en cada fotograma
    void Update()
    {
        //Controlamos la direccion del movimiento en base al Flag de 'moviendoDerecha'
        rb.velocity = right ? new Vector2(velocidad, rb.velocity.y) : new Vector2(-velocidad, rb.velocity.y);


        // Obtener la posición del sprite
        Vector3 pantallaPos = Camera.main.WorldToScreenPoint(transform.position);

        // Si el sprite choca con el borde derecho o izquierdo de la pantalla
        if (pantallaPos.x >= Screen.width)
        {
            // Cambiar la dirección del sprite
            right = false;
            // Voltear el sprite horizontalmente (cambiar la escala)         
            spriteRenderer.flipX = true;
        }
        if (pantallaPos.x < posInicial.x)
        {
            Destroy(this.gameObject);
        }
    }
}
