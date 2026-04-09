using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Header("跳跃")]
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // 用于检测落地瞬间
    private bool wasGrounded;
    private bool jumpCompletedFlag;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 地面检测
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // 重力
        velocity.y += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, velocity.y, 0) * Time.deltaTime);

        // 检测落地瞬间 → 完成一次跳跃
        if (!wasGrounded && isGrounded)
            jumpCompletedFlag = true;
        else
            jumpCompletedFlag = false;

        wasGrounded = isGrounded;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    /// <summary> 是否正在下落（未接地且垂直速度向下） </summary>
    public bool IsFalling => !isGrounded && velocity.y < 0;

    /// <summary> 是否刚刚完成一次跳跃（落地瞬间为 true，仅维持一帧） </summary>
    public bool JumpJustCompleted => jumpCompletedFlag;
}