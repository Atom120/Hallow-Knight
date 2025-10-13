using TMPro;
using UnityEngine;

public class FlyEnemie : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private bool followingPlayer;
    [SerializeField] private Rigidbody2D rigidbody2DFly;
    void Start()
    {
        rigidbody2DFly = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (followingPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;
            followingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            followingPlayer = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);   
    }
}
