using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Реализация меню паузы
/// </summary>
public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }

    /// <summary>
    /// Остановить течение времени в игре
    /// </summary>
    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        gamePaused = true;
    }

    /// <summary>
    /// Продолжить игру
    /// </summary>
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        gamePaused = false;
    }

    /// <summary>
    /// Выйти в главное меню
    /// </summary>
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Выйти из игры
    /// </summary>
    public void QuitFromGame()
    {
        Application.Quit();
    }
}