using UnityEngine;

/// <summary>
/// Информация об игровом предмете
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
    /// Спрайт предмета
    /// </summary>
    public Sprite Sprite => sprite;

    /// <summary>
    /// Высвечивающаяся метка над предметом
    /// </summary>
    public GameObject Label => label;

    /// <summary>
    /// Инструкция по подбиранию предмета (для предметов, которые нельзя подобрать, оставить null)
    /// </summary>
    public GameObject InstructionOfPickingUp => instructionOfPickingUp;

    /// <summary>
    /// Название предмета
    /// </summary>
    public string Name => name;

    /// <summary>
    /// Можно ли подобрать данный предмет в инвентарь
    /// </summary>
    public bool IsPickable => isPickable;

    /// <summary>
    /// Тип предмета
    /// </summary>
    public SpecifiedItem TypeOfItem => typeOfItem;
}

/// <summary>
/// Список вещей определённых типов
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