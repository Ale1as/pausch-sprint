using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Image healthUI;
    private Player_health Health;
    public TextMeshProUGUI fpsText;

    [Header("UI Smoothness")]
    public float smoothSpeed = 5f;  // higher = snappier, lower = smoother

    private float targetFill;

    void Start()
    {
        Health = FindAnyObjectByType<Player_health>();
    }

    void Update()
    {
        HealthBar();
        InvokeRepeating("ShowFPS", 1, 1);
    }

    void ShowFPS()
    {
        float fps = (int) (1f / Time.unscaledDeltaTime);
        fpsText.text = fps.ToString();
    }
    void HealthBar()
    {
        // Calculate target value (0–1)
        targetFill = Health.current_playerHealth / 100f;

        // Smoothly interpolate instead of forcing every frame
        healthUI.fillAmount = Mathf.Lerp(healthUI.fillAmount, targetFill, Time.deltaTime * smoothSpeed);
    }
}
