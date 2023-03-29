using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Реализация меню проигрыша
/// </summary>
public class GameOverMenuController : MonoBehaviour
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