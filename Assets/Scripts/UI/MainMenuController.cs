using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Реализация главного меню
/// </summary>
public class MainMenuController : MonoBehaviour
{
    /// <summary>
    /// При нажатии кнопки запуска игры
    /// </summary>
    public void OnStartButtonPressed()
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