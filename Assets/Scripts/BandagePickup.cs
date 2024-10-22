using UnityEngine;

public class BandagePickup : MonoBehaviour
{
    // When the player enters the trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            // Get the PlayerInventory component from the player
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            
            if (playerInventory != null)
            {
                // Add the bandage to the player's inventory
                playerInventory.AddBandage();
                
                // Destroy the bandage object from the scene
                Destroy(gameObject);
            }
        }
    }
}
