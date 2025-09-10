//Librerias - Funciones prestadas de otros scripts
using UnityEditor.Tilemaps;
using UnityEngine;

//Public - Accesible desde cualquier script, dar permiso a usar su informacion
//Clase - Conjunto de funciones y variables, forna de declarar un nuevo tipo de dato
//MovementPlayer - Nombre de la clase, debe coincidir con el nombre del archivo
//: - Herencia, indica que la clase hereda de otra clase
//MonoBehaviour - Clase base de la que derivan todas las clases de scripts en Unity

/// <summary>
/// Sebastian Selvas Garcia 05 Sep 2025
/// Movimineto del jugador
/// 
/// </summary>

public class MovementPlayer : MonoBehaviour
{
    //Variables

    //public - Accesible desde cualquier script y clase
    public Transform transformPlayer; // Transform - Componente que almacena la posicion, rotacion y escala de un objeto
    public Rigidbody2D rigidbody2DPlayer; // Rigidbody2D - Componente que permite a un objeto 2D ser afectado por la fisica
    public bool isGrounded; // Booleano, true o false
    public BoxCollider2D boxCollider2DPlayer; // BoxCollider2D - Componente que define una caja para colisiones en 2D
    public SpriteRenderer spriteRendererPlayer; // SpriteRenderer - Componente que renderiza un sprite en 2D

    //private - Solo accesible desde la misma clase

    /*tipos de datos
     * int - Entero, numeros sin decimales
     * float - Numero con decimales
     * string - Cadena de texto
     * bool - Booleano, true o false
     * char - Caracter, una sola letra o simbolo
     * double - Numero con decimales de mayor precision
     * long - Entero de mayor rango
     * short - Entero de menor rango
     */

    public int velocity = 0; // Entero
    public float jump = 0.0f; // Numero con decimales la f es de float o flotante
    //end Variables

    // Donde epieza el Frame 1. Frame 2 dejo de llamrse
    void Start()
    {
        print("Start inicia aqui");
        rigidbody2DPlayer = GetComponent<Rigidbody2D>(); // GetComponent - Obtiene el componente del tipo especificado si el objeto tiene uno
        boxCollider2DPlayer = GetComponent<BoxCollider2D>();
        isGrounded = true;//para que pueda saltar al iniciar el juego
    }//end start

    //Metodo para saltar
    void Jump()
    {
        rigidbody2DPlayer.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // ForceMode2D.Impulse - Aplica una fuerza instantanea al objeto
        isGrounded = false;
    }

    //Verifica si el jugador esta tocando el suelo
    //Metodo que se llama cuando el collider del objeto entra en contacto con otro collider
    //necesita un rigidbody para poder dectetar colisiones
    public void OnCollisionEnter2D(Collision2D collision)// Llamada al metodo onCollisionEnter2D
    {
        if (collision.gameObject.CompareTag("Ground")) // CompareTag - Compara el tag del objeto con el tag especificado
        {
            isGrounded = true;
            print("Tocando el suelo");
        }

    }

    //Desde frame 2 hasta que termine el juego
    //Loop que se repite constantemente
    // Update is called once per frame
    void Update()
    {

        //Mover al jugador en el eje X
        if (Input.GetKey(KeyCode.A)) // Input - Clase que maneja la entrada del usuario, GetKey - Devuelve true mientras se mantenga presionada la tecla especificada
        {
           // transformPlayer.position += new Vector3(-1, 0, 0) * Time.deltaTime; // Vector3 - Estructura que representa un vector en 3D, Time.deltaTime - Tiempo que ha pasado desde el ultimo frame
           rigidbody2DPlayer.AddForce(Vector2.left * velocity); // AddForce - Aplica una fuerza al Rigidbody2D, Vector2 - Estructura que representa un vector en 2D
           spriteRendererPlayer.flipX = false; // flipX - Voltea el sprite en el eje X
            print("Vamos a la izquierda");
        }


        if (Input.GetKey(KeyCode.D))
        {
           // transformPlayer.position += new Vector3(1, 0, 0) * Time.deltaTime;
            rigidbody2DPlayer.AddForce(Vector2.right * velocity);
            print("Vamos a la derecha");
            spriteRendererPlayer.flipX = true; // flipX - Voltea el sprite en el eje X
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            print("Salto");
            Jump();
        }
        //end update
    }


    //Tasa fija de frames
    /*private void FixedUpdate()
    {
        print("FixedUpdate se llama una vez por frame fijo");
    }//end FixedUpdate-*/

}//end class
