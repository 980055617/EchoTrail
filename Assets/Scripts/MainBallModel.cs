using UnityEngine;
using System.Collections.Generic;

public class MainBallModel
{
    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private bool isGrounded;
    private Vector3 velocity;

    public float MoveSpeed => moveSpeed;
    public float JumpForce => jumpForce;
    public bool IsGrounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }
    public Vector3 Velocity
    {
        get => velocity;
        set => velocity = value;
    }

    public void SetMovementParameters(float speed, float jump)
    {
        moveSpeed = speed;
        jumpForce = jump;
    }
} 