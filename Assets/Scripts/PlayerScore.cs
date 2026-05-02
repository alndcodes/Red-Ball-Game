using UnityEngine;
using TMPro; 

public class PlayerScore : MonoBehaviour
{
    [Header("Score Settings")]
    public int currentScore = 0;
    public TextMeshProUGUI scoreText; 

    [Header("Unlock Settings")]
    public int starsNeededForKey = 3; 
    
    // We need a slot for the Key and a slot for the Wall
    public GameObject keyObject; 
    public GameObject wallToDestroy; 

    private void Start()
    {
        UpdateScoreDisplay();

        // Hide the key the moment the game starts
        if (keyObject != null)
        {
            keyObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // --- LOGIC FOR STARS ---
        if (collision.CompareTag("Star"))
        {
            currentScore += 1;
            UpdateScoreDisplay();
            Destroy(collision.gameObject);

            // Check if we have enough stars to reveal the key
            if (currentScore >= starsNeededForKey)
            {
                if (keyObject != null)
                {
                    // Turn the key on!
                    keyObject.SetActive(true); 
                }
            }
        }

        // --- LOGIC FOR THE KEY ---
        if (collision.CompareTag("Key"))
        {
            // 1. Destroy the key (so it looks like we picked it up)
            Destroy(collision.gameObject);

            // 2. Destroy the wall to open the path!
            if (wallToDestroy != null)
            {
                Destroy(wallToDestroy);
            }
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Stars: " + currentScore;
        }
    }
}