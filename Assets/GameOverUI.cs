using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public void NewGame()
    {
        GameStateManager.Instance.ResetGame();
    }
}
