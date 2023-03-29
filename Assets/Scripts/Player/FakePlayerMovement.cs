using UnityEngine;

public class FakePlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform truePlayer;

    private void FixedUpdate()
    {
        transform.position = truePlayer.position;
    }
}