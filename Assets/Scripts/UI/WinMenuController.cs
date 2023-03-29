using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Реализация меню победы
/// </summary>
public class WinMenuController : MonoBehaviour
{
    /// <summary>
    /// При нажатии кнопки перезапуска игры
    /// </summary>
    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    /// <summary>
    /// При выходе из игры
    /// </summary>
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}