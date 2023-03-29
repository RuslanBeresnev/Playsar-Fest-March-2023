using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Реализация игрового таймера
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] private float gameTime = 180f;
    private float timeLeft = 180f;

    [SerializeField] private TextMeshProUGUI timerText;

    private float timeScale = 1f;
    // Сколько времени осталось до окончания эффекта изменения скорости течения времени
    private float timeScaleRemain = 0f;

    private void Awake()
    {
        timeLeft = gameTime;
    }

    private void Update()
    {
        if (timeScaleRemain > 0)
        {
            timeScaleRemain -= Time.deltaTime;
        }
        else
        {
            timeScale = 1f;
        }

        timeLeft -= Time.deltaTime * timeScale;
        timeLeft = Mathf.Clamp(timeLeft, 0, gameTime);

        string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
        string seconds = Mathf.Floor(timeLeft % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;

        if (timeLeft == 0f)
        {
            SceneManager.LoadScene("GameOverMenu");
        }
    }

    /// <summary>
    /// Изменить скорость течения времени на несколько секунд
    /// </summary>
    public void SetTimeScaleForSeconds(float timeScale, float seconds)
    {
        this.timeScale = timeScale;
        timeScaleRemain = seconds;
    }
}