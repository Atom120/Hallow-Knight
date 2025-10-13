using UnityEngine;

public class CoinGeo : MonoBehaviour
{
   [SerializeField] private float forceMagnitude = 5f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.AddForce(randomDirection * forceMagnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has collected the coin!");
            // Here you can add code to update the player's score or inventory
            Destroy(gameObject); // Remove the coin from the scene
        }
    }
}
