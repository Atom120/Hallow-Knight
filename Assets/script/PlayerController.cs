using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private bool recibiendoDanio;
    private Rigidbody2D rb;
    public int vida = 100;
    private bool vidabool = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidabool == true)
        {
            Morir();
        }
        
    }

    public void Morir()
    {
        // Aquí puedes agregar efectos de muerte, animaciones, etc.
        Debug.Log("El jugador ha muerto.");
        // Desactivar el objeto después de un breve retraso para permitir que la animación se reproduzca
        Destroy(gameObject); // Ajusta el tiempo según la duración de tu animación
    }

    public void RecibirDanio(Vector2 direccion, int cantDanio)
    {
        if (!recibiendoDanio)//si no esta recibiendo daño
        {
            recibiendoDanio = true;
            //rebote es un vector que es igual a la posicion del jugador menos la direccion del ataque
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized;
            rb.AddForce(rebote * 6, ForceMode2D.Impulse);//aplicar una fuerza al rigidbody del jugador en la direccion del rebote
            vida -= cantDanio;
            if (vida < 0)
            {
                Debug.Log("Vida del jugador: " + 0);
                vidabool = true;
            }
        }
        else
        {
            Debug.Log("Vida del jugador: " + vida);
        }
        DejarDeRecibirDanio();
    }
    
    public void DejarDeRecibirDanio()
    {
        recibiendoDanio = false;
    }

}
