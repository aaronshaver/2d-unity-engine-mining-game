using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public bool isGameOver = false;
    public GameObject gameOverCanvas;
    public BatteryManager batteryManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("GameStateManager Start: isGameOver = " + isGameOver);

        if (gameOverCanvas != null)
        {
            Debug.Log("GameStateManager Start: gameOverCanvas is assigned");
            gameOverCanvas.SetActive(false); // Ensure it's inactive at start
        }
        else
        {
            Debug.Log("GameStateManager Start: gameOverCanvas is null");
        }
    }

    public void GameOver()
    {
        Debug.Log("doing game over... isGameOver before: " + isGameOver);
        isGameOver = true;
        if (gameOverCanvas != null)
        {
            Debug.Log("setting gameover ui to active...");
            gameOverCanvas.SetActive(true); // Activate on game over
        }
        else
        {
            Debug.Log("gameOverCanvas is null in GameOver");
        }
    }

    public void ResetGame()
    {
        Debug.Log("resetting game...");
        isGameOver = false; // Reset game state
        Debug.Log("isGameOver after reset: " + isGameOver);

        if (batteryManager != null)
        {
            Debug.Log("Resetting battery...");
            batteryManager.ResetBattery(); // Reset battery
        }

        Debug.Log("Reloading scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene
    }
}
