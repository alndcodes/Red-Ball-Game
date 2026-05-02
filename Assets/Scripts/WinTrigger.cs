using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [Header("UI Elements")]
    // The slot for your "You Win" text
    public GameObject winText; 
    public GameObject replayButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object touching the win block is the Player
        if (collision.CompareTag("Player"))
        {
            // 1. Turn on the "You Win" text
            if (winText != null)
            {
                winText.SetActive(true);
                
            }
            if (replayButton != null) replayButton.SetActive(true);

            // 2. Freeze the game!
            // Time.timeScale controls how fast time moves in Unity. 
            // Setting it to 0 stops all physics and movement instantly.
            Time.timeScale = 0f; 
        }
    }
}