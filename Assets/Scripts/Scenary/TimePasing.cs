using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimePasing : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float duration = 240f; // 4 minutos

    [Header("UI (solo visual)")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Image fillBar; // opcional (Image type = Filled)

    public float remaining;
    private bool isRunning;
    private bool canStart = true; // true = se puede iniciar el contador

    void Start()
    {
        ResetTimer();
        isRunning = true; 
    }

    void Update()
    {
        if (!isRunning) return;

        remaining -= Time.deltaTime;

        if (remaining <= 0f)
        {
            SceneManager.LoadScene(5);
            remaining = 0f;
            isRunning = false; // terminó; canStart sigue en false hasta reiniciar
            Debug.Log("¡Tiempo terminado!");
        }

        UpdateUI();
    }

    [ContextMenu("Iniciar")]
    public void StartTimer()
    {
        if (!canStart) return;
        canStart = false;
        isRunning = true;
    }

    [ContextMenu("Reiniciar")]
    public void ResetTimer()
    {
        isRunning = false;
        remaining = duration;
        canStart = true;
        UpdateUI();
    }

    private void UpdateUI()
    {
        int total = Mathf.CeilToInt(remaining);
        if (timerText != null)
            timerText.text = $"{total / 60:00}:{total % 60:00}";

        if (fillBar != null)
            fillBar.fillAmount = remaining / duration;
    }
}