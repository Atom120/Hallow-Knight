using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private int  maxCountSpawners = 0;
    [SerializeField] private int countSpawners = 0;

    void Start()
    {
        maxCountSpawners = Random.Range(3, 8);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(maxCountSpawners > countSpawners)
            {
                InstantieGeoCoin();
            }
           
        }
    }

    [ContextMenu("Instantiate")]
    private void InstantieGeoCoin()
    {
        countSpawners++; 

        Instantiate(stonePrefab, transform.position + Random.insideUnitSphere * 0.5f, Quaternion.identity);
    }
}
