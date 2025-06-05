using UnityEngine;
using TMPro;

public class ProgressTracker : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI text;

    public float startY = 0f;
    public float goalY = 670000000000f;

    void Update()
    {
        if (player != null && text != null)
        {
            float progress = Mathf.InverseLerp(startY, goalY, player.position.y);
            int percent = Mathf.Clamp(Mathf.RoundToInt(progress * 100f), 0, 100);
            text.text = "Progress: " + percent + "%";
        }
    }
}
