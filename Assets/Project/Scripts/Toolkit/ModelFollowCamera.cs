using UnityEngine;

public class ModelFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;   // 相机（由你的输入脚本控制）
    public Vector3 localOffset;         // 相机在模型局部坐标系中的固定位置

    void LateUpdate()
    {
        // 1. 模型只水平跟随相机的Yaw旋转
        float yaw = cameraTransform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // 2. 计算相机相对于模型的世界偏移（随模型水平旋转而旋转）
        Vector3 worldOffset = transform.rotation * localOffset;

        // 3. 移动模型，使得相机始终位于模型的 localOffset 点
        transform.position = cameraTransform.position - worldOffset;
    }
}