using UnityEngine;

public class EnemigoAtaque : MonoBehaviour
{
    public int danio;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D colisionador = GetComponent<Collider2D>();// Obtener el componente Collider2D del objeto actual
    }
    //Oncollision2D no tiene referencias porque es un metodo que se llama automaticamente cuando ocurre una colision
    private void OnCollision2D(Collision2D collision)//Oncollision2D recibe un parametro de tipo Collision2D que contiene informacion sobre la colision
    {
        {
            if (collision.collider.CompareTag("Player"))
            {
                danio = 10;
                collision.collider.GetComponent<VidaPlayer>().RecibirDaño(danio);
                Debug.Log("Colision con Player");
            }
        }
            
    }

}
