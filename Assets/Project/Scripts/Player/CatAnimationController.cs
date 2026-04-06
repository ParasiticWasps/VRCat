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
        Debug.Log("Moveing");
        m_CatAnimator.SetBool("Moving", true);
        m_CatAnimator.SetBool("Idle", false);
    }

    public void Idle()
    {
        Debug.Log("Idle");
        m_CatAnimator.SetBool("Moving", false);
        m_CatAnimator.SetBool("Idle", true);
    }
}
