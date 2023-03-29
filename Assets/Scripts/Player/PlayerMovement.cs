using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;

    [SerializeField] private AnimationCurve ProcrastinationToForceToBed;

    [SerializeField] private float deadForceToBedValue;

    public float EnvironmentSlowdown { get; set; } = 0f;

    public float Speed => defaultSpeed * (1f - EnvironmentSlowdown);

    public bool ForbidMoving { get; set; } = false;

    private Rigidbody2D rb2D;
    PlayerAnimator playerAnimation;
    SpriteRenderer spriteRenderer;

    [SerializeField] private AIPath fakePlayerPath;

    [SerializeField] private ProcrastinationBarController procrastinationBar;

    private float ForceToBedCoef => ProcrastinationToForceToBed.Evaluate(procrastinationBar.ProcrastinationCoefficient);

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Vector2 runVector = new Vector2(xMovement, yMovement);

        Flip(xMovement);

        if (rb2D.velocity.magnitude <= deadForceToBedValue)
        {
            playerAnimation.Idle();
        }
        else
        {
            playerAnimation.Walk();
        }

        if (!ForbidMoving)
        {
            Run(runVector);
        }
    }

    void Flip(float xMovement)
    {

        if (Mathf.Sign(xMovement)>0 && xMovement!=0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Mathf.Sign(xMovement) < 0 &&  xMovement!=0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Run(Vector2 movementVector)
    {
        rb2D.velocity = ForceToBedCoef * fakePlayerPath.desiredVelocity;

        rb2D.velocity += Speed * movementVector;

        if (rb2D.velocity.x != 0)
        {
            spriteRenderer.flipX = rb2D.velocity.x > 0;
        }
    }
}