using UnityEngine;

public class Moneda : MonoBehaviour
{
    private bool estaEnSuelo = false;       // Para saber si la moneda está apoyada
    private BoxCollider2D boxCollider;      // Collider de la moneda
    private SpriteRenderer spriteRenderer;  // Para efectos visuales (opcional)

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Si la moneda no está sobre el suelo, ajustamos su posición hacia arriba
        if (!estaEnSuelo)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            if (hit.collider != null && hit.collider.CompareTag("Ground"))
            {
                estaEnSuelo = true;
                // Ajustar posición justo encima del suelo
                transform.position = new Vector2(transform.position.x, hit.collider.bounds.max.y + boxCollider.bounds.extents.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar colisión con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes agregar puntos o sonido
            Destroy(gameObject);
        }

        // Detectar colisión con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            estaEnSuelo = true;
        }
    }
}
