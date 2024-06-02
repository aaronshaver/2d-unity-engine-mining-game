using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    public int batteryLife = 100;
    private int initialBatteryLife;
    private float timer = 0;
    public TextMeshProUGUI batteryText;

    void Start()
    {
        initialBatteryLife = batteryLife;
        UpdateBatteryText();
    }

    void Update()
    {
        if (GameStateManager.Instance.isGameOver) return;

        timer += Time.deltaTime;
        if (timer >= 1)
        {
            batteryLife--;
            timer = 0;
        }

        if (batteryLife <= 0)
        {
            batteryLife = 0;
            GameStateManager.Instance.GameOver();
        }

        UpdateBatteryText();
    }

    public void ResetBattery()
    {
        batteryLife = initialBatteryLife;
        timer = 0;
        UpdateBatteryText();
    }

    private void UpdateBatteryText()
    {
        batteryText.text = "Battery: " + batteryLife;
    }
}
