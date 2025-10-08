using UnityEngine;

public class Crowler : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float speed = 2f;
    public bool movingRight = true;
    [Header("Detección")]
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkDistanceX = 1f;
    public float checkDistanceY = 0.3f;
    public LayerMask ayerMaskWall;
    public Transform transformEnemy;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    //
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transformEnemy = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        // Operador ternario para dirección, primer valor si es true, segundo si es false
        float moveDir = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(moveDir * speed, rb.linearVelocity.y);// Parametros que recibe el vector2 son x e y

        // Detectar pared y falta de suelo
        bool hitWall = Physics2D.Raycast(wallCheck.position, movingRight ? Vector2.right : Vector2.left, checkDistanceX, ayerMaskWall);
        bool noGround = !Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistanceY, ayerMaskWall);

        // Cambiar dirección
        if (hitWall || noGround)
        {
            Flip();
        }
    }

    private void Update()
    {
        // Debug Rays
        Debug.DrawRay(wallCheck.position, (movingRight ? Vector2.right : Vector2.left) * checkDistanceX, Color.red);
        //CircleCast
        Debug.DrawRay(groundCheck.position, Vector2.down * checkDistanceY, Color.blue);

    }

    void FlipRaycats()
    {
        Debug.Log("FlipRaycats");
        // Invierte solo el tranform (no el sprite)
        transformEnemy.Rotate(0f, 180f, 0f);
    }

    void Flip()
    {
        Debug.Log("Flip");
        //rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Detener el movimiento horizontal antes de girar
        movingRight = !movingRight;
        // Invierte solo el sprite (no el transform completo)
        //spriteRenderer.flipX = !spriteRenderer.flipX;
        Debug.Log("Flip tranform ");
        // Invierte solo el tranform (no el sprite)
        transformEnemy.Rotate(0f, 180f, 0f);
    }
}