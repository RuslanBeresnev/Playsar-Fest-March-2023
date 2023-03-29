using UnityEngine;

/// <summary>
/// ���������� ��������� ���������� �����
/// </summary>
public class PickingUp : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    private Inventory inventory;
    // ������������ � ������� ������ �������
    private Item detectedItem;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void FixedUpdate()
    {
        detectedItem = DetectItemWithinRadius();
        if (detectedItem == null)
        {
            return;
        }

        ShowItemLabel();
        if (detectedItem.IsPickable)
        {
            ShowPickingUpInstructions();
        }

        // ����� ����� ������� �� ��������, ������ ��� ����� � ���������� �� ����������
        // (���� ������� �����������)
        if (Vector2.Distance(transform.position, detectedItem.transform.position) > detectionRadius)
        {
            HideLabelAndInstruction();
        }

        CheckPickingUp();
    }

    /// <summary>
    /// ���������� ����� ������� � ��������� ������� �� ������
    /// </summary>
    private Item DetectItemWithinRadius()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, detectionRadius);
        if (collider == null)
        {
            return null;
        }

        Item item = collider.gameObject.GetComponent<Item>();
        if (item != null)
        {
            return item;
        }
        return null;
    }

    /// <summary>
    /// �������� �� ���������� �������� �������
    /// </summary>
    private void CheckPickingUp()
    {
        if (Input.GetKey(KeyCode.E) &&
            Vector2.Distance(transform.position, detectedItem.transform.position) < detectionRadius)
        {
            var effectsComponent = detectedItem.GetComponent<ItemWithEffects>();
            if (effectsComponent != null)
            {
                effectsComponent.PerformEffectsAction();
                RemovePickedUpItemFromMap();
                return;
            }

            bool itemPickedUp = inventory.TryToPickUpItem(detectedItem);
            if (itemPickedUp)
            {
                RemovePickedUpItemFromMap();
            }
        }
    }

    /// <summary>
    /// ������ ����������� ������� � �����
    /// </summary>
    private void RemovePickedUpItemFromMap()
    {
        // ���� ��� ������ ������� �������� �� �����
        var spawnSlotInMap = detectedItem.transform.parent.GetComponent<SpawnItemSlot>();
        if (spawnSlotInMap == null)
        {
            Debug.LogError("Each pickable item in the map must have parent transform" +
                           " with the SpawnItemSlot component");
        }
        else
        {
            spawnSlotInMap.RemoveItem();
            detectedItem = null;
        }
    }

    /// <summary>
    /// �������� ����� ��� ���������
    /// </summary>
    private void ShowItemLabel()
    {
        detectedItem.Label.SetActive(true);
    }

    /// <summary>
    /// ��� ����������� ��������� ������������� ������������ ����������, ��� ���������
    /// (��������, �������� ������� "E")
    /// </summary>
    private void ShowPickingUpInstructions()
    {
        detectedItem.InstructionOfPickingUp.SetActive(true);
    }

    /// <summary>
    /// ������ ����� � ���������� �� ����������
    /// </summary>
    private void HideLabelAndInstruction()
    {
        if (detectedItem.Label != null)
        {
            detectedItem.Label.SetActive(false);
        }
        if (detectedItem.InstructionOfPickingUp != null)
        {
            detectedItem.InstructionOfPickingUp.SetActive(false);
        }
    }
}