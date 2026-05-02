using UnityEngine;
using UnityEngine.SceneManagement; // We need this to load levels!

public class LevelManager : MonoBehaviour
{
    // Note: This must say "public void" so the button can find it!
    public void RestartLevel()
    {
        // 1. Unfreeze the game! (Crucial step, otherwise the reloaded game will still be frozen)
        Time.timeScale = 1f;

        // 2. Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}