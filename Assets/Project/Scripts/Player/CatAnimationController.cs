using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimationController : Singleton<CatAnimationController>
{
    private Animator m_CatAnimator;

    private void Awake()
    {
        m_CatAnimator = GetComponent<Animator>();
    }

    public void Moveing()
    {
        //Debug.Log("Moveing");
        m_CatAnimator.SetBool("Moving", true);
    }

    public void Idle()
    {
        //Debug.Log("Idle");
        m_CatAnimator.SetBool("Moving", false);
    }

    public void Jumping()
    {
        m_CatAnimator.SetBool("Jumping", true);
    }

    public void FloatingJump()
    {
        StartCoroutine(FloatingJumpingCoroutine());
    }

    private IEnumerator FloatingJumpingCoroutine()
    {
        m_CatAnimator.speed = 0.0f;

        yield return new WaitUntil(() => PlayerController.Get().IsFalling);

        m_CatAnimator.speed = 1.0f;
    }

    public void JumpDown()
    {
        StartCoroutine(JumpDownCoroutine());
    }

    private IEnumerator JumpDownCoroutine()
    {
        m_CatAnimator.speed = 0.0f;

        yield return new WaitUntil(() => PlayerController.Get().JumpJustCompleted);

        m_CatAnimator.speed = 1.0f;
    }

    public void EndJumping()
    {
        m_CatAnimator.SetBool("Jumping", false);
    }
}
