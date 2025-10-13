using Unity.VisualScripting;
using UnityEngine;

public class golpe : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe1;
    [SerializeField] private Transform controladorGolpe2;
    [SerializeField] private Transform controladorGolpe3;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danioGolpe;
    [SerializeField] private GameObject golpeSprite;
    private GameObject golpeSpriteInstance;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))//Fire1 es el boton izquierdo del raton o Ctrl izq
        {
            Golpe1();
        }
        Destroy(golpeSpriteInstance, 0.5f); // Destruye el objeto golpe después de 0.5 segundos (ajusta el tiempo según la duración de tu animación)

        if (Input.GetButtonDown("Fire2"))//Fire2 es el boton derecho del raton o Ctrl der
        {
            Golpe2();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Golpe3();
        }
    }

    private void OnEnable()
    { 
        Destroy(golpeSpriteInstance,0.5f);
    }

    private void Golpe1()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe1.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo") && colisionador is BoxCollider2D)
            {
                Vector2 direccion = (colisionador.transform.position - transform.position).normalized;
                colisionador.GetComponent<Enemigo>().TomarDaño(danioGolpe, direccion);
            }

            if (colisionador.CompareTag("Puerta"))
            {
                Puerta puerta = colisionador.GetComponent<Puerta>();
                if (puerta != null)
                    puerta.TomarDaño(danioGolpe); // Llamamos al método sin necesidad de knockback
            }
        }

        golpeSpriteInstance = Instantiate(golpeSprite, controladorGolpe1.position, Quaternion.identity);
        Debug.Log("Golpe");
    }


    private void Golpe2()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe2.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo") && colisionador is BoxCollider2D)
            {
                Vector2 direccion = (colisionador.transform.position - transform.position).normalized;
                colisionador.GetComponent<Enemigo>().TomarDaño(danioGolpe, direccion);
            }

            if (colisionador.CompareTag("Puerta"))
            {
                Puerta puerta = colisionador.GetComponent<Puerta>();
                if (puerta != null)
                    puerta.TomarDaño(danioGolpe); // Llamamos al método sin necesidad de knockback
            }
        }


        golpeSpriteInstance = Instantiate(golpeSprite, controladorGolpe2.position, Quaternion.identity);
        Debug.Log("Golpe");
    }


    private void Golpe3()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe3.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo") && colisionador is BoxCollider2D)
            {
                Vector2 direccion = (colisionador.transform.position - transform.position).normalized;
                colisionador.GetComponent<Enemigo>().TomarDaño(danioGolpe, direccion);
            }

            if (colisionador.CompareTag("Puerta"))
            {
                Puerta puerta = colisionador.GetComponent<Puerta>();
                if (puerta != null)
                    puerta.TomarDaño(danioGolpe); // Llamamos al método sin necesidad de knockback
            }
        }


        golpeSpriteInstance = Instantiate(golpeSprite, controladorGolpe3.position, Quaternion.identity);
        Debug.Log("Golpe");
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe1.position, radioGolpe);
        Gizmos.DrawWireSphere(controladorGolpe2.position, radioGolpe);
        Gizmos.DrawWireSphere(controladorGolpe3.position, radioGolpe);
    }

}
