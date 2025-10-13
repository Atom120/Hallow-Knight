using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int vida = 100;

   public void RecibirDaño(int daño)
    {
        vida -= daño;
        Debug.Log("Vida del jugador: " + vida);
        if (vida <= 0)
        {
            Morir();
        }
    }
    private void Morir()
    {
        // Aquí puedes agregar efectos de muerte, animaciones, etc.
        Debug.Log("El jugador ha muerto.");
        // Desactivar el objeto después de un breve retraso para permitir que la animación se reproduzca
        Destroy(gameObject); // Ajusta el tiempo según la duración de tu animación
    }
}
