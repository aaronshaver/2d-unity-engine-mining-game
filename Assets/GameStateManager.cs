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
    }

    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false); // Ensure it's inactive at start
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // Activate on game over
        }
    }

    public void ResetGame()
    {
        isGameOver = false; // Reset game state
        batteryManager.ResetBattery(); // Reset battery
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene
    }
}
