using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Реализация инвентаря
/// </summary>
public class Inventory : MonoBehaviour
{
    private List<Item> items = new() { null, null, null, null, null };
    // Список ссылок на компонент Image для содержимого каждого слота
    [SerializeField] private List<Image> imagesInSlots = new();

    // Рассчитан на сбор ПО ОДНОМУ предмету каждого нужного типа
    [SerializeField] private List<SpecifiedItem> requiredItemsTypes = new()
    { SpecifiedItem.StudentID, SpecifiedItem.Pass, SpecifiedItem.Pen, SpecifiedItem.Keys, SpecifiedItem.Chocolate };
    // Типы уже собранных необходимых предметов
    private List<SpecifiedItem> collectedRequiredTypes = new();

    /// <summary>
    /// Собраны ли все необходимые предметы
    /// </summary>
    public bool RequiredItemsCollected { get; private set; } = false;

    /// <summary>
    /// Общий экземпляр данного класса
    /// </summary>
    public static Inventory Shared { get; private set; }

    private void Awake()
    {
        Shared = this;
    }

    /// <summary>
    /// Попытаться подобрать предмет в инвентарь
    /// </summary>
    public bool TryToPickUpItem(Item item)
    {
        if (!item.IsPickable)
        {
            return false;
        }

        for (int i = 0; i < 5; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                imagesInSlots[i].sprite = item.Sprite;

                if (!RequiredItemsCollected)
                {
                    if (requiredItemsTypes.Contains(item.TypeOfItem) && !collectedRequiredTypes.Contains(item.TypeOfItem))
                    {
                        collectedRequiredTypes.Add(item.TypeOfItem);
                    }
                    if (collectedRequiredTypes.Count == requiredItemsTypes.Count)
                    {
                        RequiredItemsCollected = true;
                    }
                }

                return true;
            }
        }

        return false;
    }
}