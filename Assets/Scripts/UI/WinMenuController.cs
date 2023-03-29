using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ���� ������
/// </summary>
public class WinMenuController : MonoBehaviour
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