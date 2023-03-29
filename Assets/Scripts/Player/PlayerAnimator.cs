using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk()
    {
        animator.SetBool("walk", true);
    }

    public void Idle()
    {
        animator.SetBool("walk", false);
    }
}