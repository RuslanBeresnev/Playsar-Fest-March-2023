using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnItemSlot> spawnItemSlots;
    [SerializeField] private List<GameObject> itemPrefabsToSpawn;

    public IEnumerable<GameObject> SceneItems => spawnItemSlots.Select(slot => slot.Item);

    public event UnityAction OnSpawn;

    public void Start()
    {
        SpawnItems(itemPrefabsToSpawn);
    }

    private void SpawnItems(List<GameObject> items)
    {
        Shuffle(items);
        for (int i = 0; i < items.Count; i++)
        {
            spawnItemSlots[i].Item = Instantiate(items[i]);
        }
        OnSpawn?.Invoke();
    }

    public static void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void OnValidate()
    {
        if (spawnItemSlots.Count != itemPrefabsToSpawn.Count)
        {
            Debug.LogError("Count of items must be the same");
        }
    }
}
