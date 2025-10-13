using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida = 3;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float tiempoParpadeo = 0.1f; // Tiempo que dura el parpadeo
    [SerializeField] private GameObject monedas;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TomarDaño(float daño, Vector2 direccionKnockback)
    {
        vida -= daño;

        // Knockback
        if (rb != null)
            rb.AddForce(direccionKnockback * knockbackForce, ForceMode2D.Impulse);

        // Parpadeo visual
        StartCoroutine(Parpadear());

        // Animación
        if (animator != null)
            animator.SetTrigger("Golpeado");

        if (vida <= 0)
            Morir();
    }

    private IEnumerator Parpadear()//Funcion para usar corrutinas
    {
        // Apagar el sprite
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(tiempoParpadeo);

        // Encenderlo de nuevo
        spriteRenderer.enabled = true;
    }

    private void Morir()
    {
        // Activar animación de muerte
        if (animator != null)
            animator.SetTrigger("Muerte");

        // Instanciar 5 monedas al azar alrededor del enemigo
        for (int i = 0; i < 5; i++)
        {
            // Calculamos una posición cercana al enemigo para que las monedas no aparezcan exactamente en el mismo punto
            Vector2 posicionMoneda = new Vector2(
                transform.position.x + Random.Range(-0.5f, 0.5f), // desplazamiento aleatorio
                transform.position.y + Random.Range(-0.5f, 0.5f) 
            );

            // Instanciamos la moneda en la posición calculada
            Instantiate(monedas, posicionMoneda, Quaternion.identity);
        }

        // Destruir el enemigo después de 0.2 segundos
        Destroy(gameObject, 0.2f);
    }

}
