using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Extra"))
        {
            CollectCoin();
        }
    }

    void CollectCoin()
    {
        // Customize this method based on what should happen when a coin is collected
        Debug.Log("Coin collected!"); // Display a message when a coin is collected
        Destroy(gameObject); // Destroy the coin object
        // Add logic here to update score, play a sound, or any other action upon collecting a coin
    }
}
