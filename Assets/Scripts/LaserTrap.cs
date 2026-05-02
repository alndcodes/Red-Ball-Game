using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [Header("UI Elements")]
    // This creates an empty slot in the Inspector to drop your Text object into
    public GameObject deathText; 
    public GameObject replayButton;

    // OnTriggerEnter2D automatically runs the exact moment something touches the "Is Trigger" collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that touched the laser has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // 1. Turn on the "You Died" text
            if (deathText != null)
            {
                deathText.SetActive(true);
            }
            if (replayButton != null) replayButton.SetActive(true);
            // 2. Destroy the player object so it disappears from the game
            Destroy(collision.gameObject);
            
            // Optional: You could also freeze the game here by setting Time.timeScale = 0;
        }
    }
}