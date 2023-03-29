using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrol : MonoBehaviour
{
    [SerializeField] private List<GameObject> patrolPoints = new();
    [SerializeField] private GameObject player;
    [SerializeField] private Timer timer;
    [SerializeField] private float playerDetectionDistance = 5f;
    // Период времени, в течение которого кот после глажки отходит от игрока и продолжает патрулировать территорию,
    // не отвлекаясь на игрока
    [SerializeField] private float catCooldownDuration = 8f;
    [SerializeField] private float interactionWithPlayerDuration = 2f;
    // Коэффициент ускорения времени во время глажки кота
    [SerializeField] private float timeAcceleration = 5f;

    private Rigidbody2D rb2D;

    private AIPath path;
    private AIDestinationSetter destSetter;

    private SpriteRenderer spriteRenderer;

    private int currentTargetIndex = 0;
    // Может ли в данный момент времени кот отвлечься на игрока
    private bool catCanDisturbToPlayer = true;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        path = GetComponent<AIPath>();
        destSetter = GetComponent<AIDestinationSetter>();
        destSetter.target = patrolPoints[0].transform;
    }

    private void FixedUpdate()
    {
        spriteRenderer.flipX = path.desiredVelocity.x < 0;
        if (path.reachedDestination)
        {
            currentTargetIndex = (currentTargetIndex + 1) % patrolPoints.Count;
            destSetter.target = patrolPoints[currentTargetIndex].transform;
        }

        if (catCanDisturbToPlayer)
        {
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < playerDetectionDistance)
        {
            destSetter.target = player.transform;
        }
        else
        {
            destSetter.target = patrolPoints[currentTargetIndex].transform;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 1f)
        {
            StartCoroutine(CatAndPlayerInteraction());
        }
    }

    private IEnumerator CatAndPlayerInteraction()
    {
        // Анимация глажки кота (добавить сюда)

        player.GetComponent<PlayerMovement>().ForbidMoving = true;
        catCanDisturbToPlayer = false;
        float currentMaxSpeed = path.maxSpeed;
        path.maxSpeed = 0f;

        timer.SetTimeScaleForSeconds(timeAcceleration, interactionWithPlayerDuration);
        yield return new WaitForSeconds(interactionWithPlayerDuration);

        player.GetComponent<PlayerMovement>().ForbidMoving = false;
        path.maxSpeed = currentMaxSpeed;

        StartCoroutine(PerformCooldownAfterCatPetting());
    }

    private IEnumerator PerformCooldownAfterCatPetting()
    {
        destSetter.target = patrolPoints[currentTargetIndex].transform;
        yield return new WaitForSeconds(catCooldownDuration);
        catCanDisturbToPlayer = true;
    }
}