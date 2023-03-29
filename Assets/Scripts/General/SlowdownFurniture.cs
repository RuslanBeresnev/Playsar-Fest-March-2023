using UnityEngine;

/// <summary>
/// –еализаци€ зон окружени€, которые замедл€ют игрока
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class SlowdownFurniture : MonoBehaviour
{
    [SerializeField] private float slowdownCofficient;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out var player))
        {
            player.EnvironmentSlowdown = slowdownCofficient;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out var player))
        {
            player.EnvironmentSlowdown = 0f;
        }
    }
}