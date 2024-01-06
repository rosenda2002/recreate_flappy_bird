using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5f;
    public float coinDisappearTime = 3f; // Time until coins disappear

    private bool isGameRunning = true; // Flag to control spawning

    void Start()
    {
        // Start spawning coins if the game is running
        if (isGameRunning)
            InvokeRepeating("SpawnCoins", spawnInterval, spawnInterval);
    }

    void SpawnCoins()
    {
        if (isGameRunning)
        {
            Vector3 coinPosition = spawnPoint.position;

           
                GameObject newCoin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                StartCoroutine(WaitAndDestroy(newCoin, coinDisappearTime)); // Start coroutine to destroy the coin after a delay
            
        }
    }

    IEnumerator WaitAndDestroy(GameObject coin, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (coin != null) // Check if the coin still exists before destroying it
        {
            Destroy(coin);
        }
    }

    // Method to stop coin spawning when the game is over
    public void StopCoinSpawning()
    {
        isGameRunning = false;
        CancelInvoke("SpawnCoins"); // Stop the spawning process
    }
}
