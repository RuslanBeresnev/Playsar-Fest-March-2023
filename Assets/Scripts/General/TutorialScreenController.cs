using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ��������� ����� � ��������� ������
/// </summary>
public class TutorialScreenController : MonoBehaviour
{
    /// <summary>
    /// ������� �� ������� �����
    /// </summary>
    public void OnReadButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }
}