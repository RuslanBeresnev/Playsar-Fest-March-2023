using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� �������� ����
/// </summary>
public class MainMenuController : MonoBehaviour
{
    /// <summary>
    /// ��� ������� ������ ������� ����
    /// </summary>
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    /// <summary>
    /// ��� ������ �� ����
    /// </summary>
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}