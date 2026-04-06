using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRControllerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionProperty m_Move;

    private void Awake()
    {
        Register();
    }

    private void Register()
    {
        m_Move.action.performed += OnMoveEvent;
        m_Move.action.canceled += OnMoveCancelEvent;
    }

    /// <summary>
    /// 移动事件
    /// </summary>
    /// <param name="context"></param>
    private void OnMoveEvent(InputAction.CallbackContext context)
    {
        CatAnimationController.Get().Moveing();
    }

    /// <summary>
    /// 取消移动事件
    /// </summary>
    /// <param name="context"></param>
    private void OnMoveCancelEvent(InputAction.CallbackContext context)
    {
        CatAnimationController.Get().Idle();
    }
}