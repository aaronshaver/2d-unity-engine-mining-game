using UnityEngine;
using TMPro;
using System.Collections;

public class BatteryManager : MonoBehaviour
{
    public int batteryLife = 100;
    private int initialBatteryLife;
    private float timer = 0;
    public TextMeshProUGUI batteryText;
    public float incrementInterval = 0.1f; // 100 milliseconds
    public int incrementAmount = 1;

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
        timer = 0;
        StopAllCoroutines(); // Stop any existing coroutine
        StartCoroutine(IncreaseBatteryLifeGradually());
    }

    private IEnumerator IncreaseBatteryLifeGradually()
    {
        while (batteryLife < initialBatteryLife)
        {
            batteryLife += incrementAmount;
            if (batteryLife > initialBatteryLife)
            {
                batteryLife = initialBatteryLife;
            }
            UpdateBatteryText();
            yield return new WaitForSeconds(incrementInterval);
        }
    }

    private void UpdateBatteryText()
    {
        batteryText.text = "Battery: " + batteryLife;
    }
}
