using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    int danio = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Aquí puedes agregar movimiento o IA del enemigo
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Calculamos dirección desde el enemigo hacia el jugador (corregido: resta, no suma)
            Vector2 direccion = (other.transform.position - transform.position).normalized;

            // El jugador recibe daño
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.RecibirDanio(direccion, danio); // daño 
                Debug.Log("Enemigo atacó al jugador"); // <-- Mensaje en consola
            }

            // Empuje del jugador al recibir golpe
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Aplica un pequeño empuje en dirección opuesta
                Vector2 fuerzaEmpuje = direccion * 5f; // puedes ajustar la fuerza
                playerRb.AddForce(fuerzaEmpuje, ForceMode2D.Impulse);
            }
        }
    }
}
