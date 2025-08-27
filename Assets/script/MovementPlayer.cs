//Librerias - Funciones prestadas de otros scripts
using UnityEngine;

//Public - Accesible desde cualquier script, dar permiso a usar su informacion
//Clase - Conjunto de funciones y variables, forna de declarar un nuevo tipo de dato
//MovementPlayer - Nombre de la clase, debe coincidir con el nombre del archivo
//: - Herencia, indica que la clase hereda de otra clase
//MonoBehaviour - Clase base de la que derivan todas las clases de scripts en Unity

public class MovementPlayer : MonoBehaviour
{
    //Variables


    //end Variables

    // Donde epieza el Frame 1. Frame 2 dejo de llamrse
    void Start()
    {
        print("Start inicia aqui");

    }//end start

    //Desde frame 2 hasta que termine el juego
    //Loop que se repite constantemente
    // Update is called once per frame
    void Update()
    {
        print("Update se llama una vez por frame");

    }//end update


    //Tasa fija de frames
    private void FixedUpdate()
    {
        print("FixedUpdate se llama una vez por frame fijo");
    }//end FixedUpdate-

}//end class
