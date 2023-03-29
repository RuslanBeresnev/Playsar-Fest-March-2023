using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Реализация поведения сцены с обучением игрока
/// </summary>
public class TutorialScreenController : MonoBehaviour
{
    /// <summary>
    /// Перейти на главную сцену
    /// </summary>
    public void OnReadButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }
}