using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ���� ���������
/// </summary>
public class GameOverMenuController : MonoBehaviour
{
    /// <summary>
    /// ��� ������� ������ ����������� ����
    /// </summary>
    public void OnRestartButtonPressed()
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