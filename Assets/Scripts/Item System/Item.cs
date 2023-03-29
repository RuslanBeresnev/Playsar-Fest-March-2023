using UnityEngine;

/// <summary>
/// ���������� �� ������� ��������
/// </summary>
public class Item : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject label;
    [SerializeField] private GameObject instructionOfPickingUp;
    [SerializeField] private SpecifiedItem typeOfItem;
    [SerializeField] private new string name;
    [SerializeField] private bool isPickable = true;

    /// <summary>
    /// ������ ��������
    /// </summary>
    public Sprite Sprite => sprite;

    /// <summary>
    /// ��������������� ����� ��� ���������
    /// </summary>
    public GameObject Label => label;

    /// <summary>
    /// ���������� �� ���������� �������� (��� ���������, ������� ������ ���������, �������� null)
    /// </summary>
    public GameObject InstructionOfPickingUp => instructionOfPickingUp;

    /// <summary>
    /// �������� ��������
    /// </summary>
    public string Name => name;

    /// <summary>
    /// ����� �� ��������� ������ ������� � ���������
    /// </summary>
    public bool IsPickable => isPickable;

    /// <summary>
    /// ��� ��������
    /// </summary>
    public SpecifiedItem TypeOfItem => typeOfItem;
}

/// <summary>
/// ������ ����� ����������� �����
/// </summary>
public enum SpecifiedItem
{
    StudentID,
    Pass,
    Pen,
    Keys,
    Chocolate,
    ItemWithEffect,
    Furniture
}