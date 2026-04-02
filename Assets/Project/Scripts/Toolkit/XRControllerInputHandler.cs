using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRControllerInputHandler : MonoBehaviour
{
    public InputActionProperty leftMove;
    public InputActionProperty rightPerform;

    //public XRController leftController; // 在Inspector中拖入左手柄的XR Controller组件
    //public XRController rightController; // 在Inspector中拖入右手柄的XR Controller组件

    private void Start()
    {
        // 监听输入动作的触发事件
        leftMove.action.performed += OnActionPerformed;
    }

    private void OnActionPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("输入动作触发，执行对应功能");
    }

    //private void OnEnable()
    //{
    //    leftController.selectUsaged.AddListener(OnTriggerPressed);
    //    // 注册扳机键按下事件
    //    leftController.selectPressed.AddListener(OnTriggerPressed);
    //    rightController.selectPressed.AddListener(OnTriggerPressed);

    //    // 注册A键（primary按钮）按下事件，根据实际手柄配置，A键可能对应primaryButton
    //    leftController.primaryButtonPressed.AddListener(OnAPrimaryButtonPressed);
    //    rightController.primaryButtonPressed.AddListener(OnAPrimaryButtonPressed);
    //}

    //private void OnDisable()
    //{
    //    leftController.selectPressed.RemoveListener(OnTriggerPressed);
    //    rightController.selectPressed.RemoveListener(OnTriggerPressed);
    //    leftController.primaryButtonPressed.RemoveListener(OnAPrimaryButtonPressed);
    //    rightController.primaryButtonPressed.RemoveListener(OnAPrimaryButtonPressed);
    //}

    //private void Update()
    //{
    //    // 读取摇杆值，例如从右手柄读取
    //    Vector2 joystickValue = rightController.inputDevice?.ReadVector2Value(CommonUsages.primary2DAxis) ?? Vector2.zero;

    //    if (joystickValue.y > 0.5f)
    //    {
    //        Debug.Log("摇杆向前推，执行A功能");
    //        // 执行A功能
    //    }
    //}

    //private void OnTriggerPressed(SelectEnterEventArgs args)
    //{
    //    Debug.Log("扳机键按下，执行B功能");
    //    // 执行B功能
    //}

    //private void OnAPrimaryButtonPressed(ButtonPressedEventArgs args)
    //{
    //    Debug.Log("A按钮按下，执行C功能");
    //    // 执行C功能
    //}
}