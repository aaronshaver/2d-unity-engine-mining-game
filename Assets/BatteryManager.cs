using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    public int batteryLife = 100;
    private float timer = 0;
    public TextMeshProUGUI batteryText;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            batteryLife--;
            timer = 0;
        }

        if (batteryLife < 0)
        {
            batteryLife = 0;
        }

        batteryText.text = "Battery: " + batteryLife.ToString();
    }
}
