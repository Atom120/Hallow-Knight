using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour
{
    [SerializeField] private float vida = 3;          // Cantidad de golpes que soporta
    [SerializeField] private float tiempoParpadeo = 0.1f; // Tiempo que dura el parpadeo
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Método que se llama desde el golpe del jugador
    public void TomarDaño(float daño)
    {
        vida -= daño;

        // Parpadeo visual
        StartCoroutine(Parpadear());

        // Animación de golpe
        if (animator != null)
            animator.SetTrigger("Golpeado");

        // Si la vida llega a 0 → destruir puerta
        if (vida <= 0)
            Morir();
    }

    private IEnumerator Parpadear()
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

        // Destruir el objeto después de un pequeño retraso para ver la animación
        Destroy(gameObject, 0.2f);
    }
}
