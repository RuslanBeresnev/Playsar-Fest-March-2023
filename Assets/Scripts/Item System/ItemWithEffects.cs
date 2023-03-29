using UnityEngine;

/// <summary>
/// Предмет с дополнительными эффектами при подбирании
/// Для таких предметов скрипт добавляется помимо основного скрипта Item
/// </summary>
[RequireComponent(typeof(Item))]
public class ItemWithEffects : MonoBehaviour
{
    [SerializeField] private float accelerationCoefficient = 1f;
    [SerializeField] private float procrastinationDecrease = 0f;

    /// <summary>
    /// Произвести действие эффектов данного предмета на персонажа
    /// </summary>
    public void PerformEffectsAction()
    {
        ProcrastinationBarController.Shared.DecreaseProcrastination(procrastinationDecrease);
        // Сделать также изменение скорость игрока
    }
}