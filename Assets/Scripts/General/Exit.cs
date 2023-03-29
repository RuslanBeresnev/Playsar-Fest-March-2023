using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Реализация механики окончания игры
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Exit : MonoBehaviour
{
    [SerializeField] private UnityEvent OnExitReached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out var player) && Inventory.Shared.RequiredItemsCollected)
        {
            OnExitReached.Invoke();
            SceneManager.LoadScene("WinMenu");
        }
    }
}