using DG.Tweening;
using System;
using UnityEngine;

public class FadeController : Singleton<FadeController>
{
    [SerializeField] private Material m_FadeMaterial;

    private Tween fadeTween;

    private void Start()
    {
        Cover(0.0f, () => Bright(3.0f, null));
    }

    public void Cover(float duration, Action callback)
    {
        KillTween();
        fadeTween = DOTween.To(
            () => m_FadeMaterial.GetFloat("_Alpha"),   // 获取当前值
            (x) => m_FadeMaterial.SetFloat("_Alpha", x), // 设置新值
            1.0f,                                      // 目标值
            duration
        ).OnComplete(() => callback?.Invoke());
    }

    public void Bright(float duration, Action callback)
    {
        KillTween();
        fadeTween = DOTween.To(
            () => m_FadeMaterial.GetFloat("_Alpha"),
            (x) => m_FadeMaterial.SetFloat("_Alpha", x),
            0.0f,
            duration
        ).OnComplete(() => callback?.Invoke());
    }

    private void KillTween()
    {
        fadeTween?.Kill();
        fadeTween = null;
    }

    private void OnDestroy()
    {
        KillTween();
    }
}