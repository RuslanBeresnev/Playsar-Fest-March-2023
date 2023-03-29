using UnityEngine;

public class SpawnItemSlot : MonoBehaviour
{
    private GameObject item;

    public GameObject Item
    {
        get
        {
            return item;
        }
        set
        {
            item = value;
            item.SetActive(true);
            item.transform.position = transform.position;
            item.transform.SetParent(transform);
        }
    }

    public GameObject RemoveItem()
    {
        item.gameObject.SetActive(false);
        item.transform.SetParent(null);
        return item;
    }
}