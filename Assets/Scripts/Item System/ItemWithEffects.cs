using UnityEngine;

/// <summary>
/// ������� � ��������������� ��������� ��� ����������
/// ��� ����� ��������� ������ ����������� ������ ��������� ������� Item
/// </summary>
[RequireComponent(typeof(Item))]
public class ItemWithEffects : MonoBehaviour
{
    [SerializeField] private float accelerationCoefficient = 1f;
    [SerializeField] private float procrastinationDecrease = 0f;

    /// <summary>
    /// ���������� �������� �������� ������� �������� �� ���������
    /// </summary>
    public void PerformEffectsAction()
    {
        ProcrastinationBarController.Shared.DecreaseProcrastination(procrastinationDecrease);
        // ������� ����� ��������� �������� ������
    }
}