using UnityEngine;

public class MovemntEnemy : MonoBehaviour
{
    //No slaga en el inspector [SerializeField] private float speedRun = 4f;
    [SerializeField] private float speedWalk;
    [SerializeField] private Transform controladorSuelo;//para saber donde esta
    [SerializeField] private float distanciaSuelo;//La del controlador hacía abajo
    [SerializeField] private bool moviminetoDerecha;//para saber que es suelo

    private Rigidbody2D rb;//para mover el enemigo


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Inicializa el Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.left * speedWalk);
    }

    private void FixedUpdate()//Llama fisicas cada cierto tiempo
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distanciaSuelo);//Lanza el rayo hacía abajo desde la posición del controladorSuelo
        //raycastHit2D genera una liena. Toma la posicion del controladorSuelo, Luego la direccion,hacía abajo y la distancia
        Debug.DrawRay(controladorSuelo.position, Vector2.down * distanciaSuelo, Color.red);//Dibuja el rayo en la escena
      

        if (informacionSuelo.collider == false)//Si el rayo no colisiona con nada
        {
            Girar();//Llama al metodo girar
        }

    }

    private void Girar()
    {
        moviminetoDerecha = !moviminetoDerecha;//Cambia el valor de moviminetoDerecha a su valor contrario
        transform.Rotate(0f, 180f, 0f);//Rota el enemigo 180 grados en el eje Y

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;//Color del gizmo
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distanciaSuelo);//Dibuja una linea desde la posicion del controladorSuelo hacía abajo hasta la distanciaSuelo
        //Inicia desde la posicion del controladorSuelo y va hacía abajo la distancia del suelo
    }
}
