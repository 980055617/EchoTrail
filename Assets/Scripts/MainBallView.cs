using UnityEngine;

public class MainBallView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 movement)
    {
        rb.AddForce(movement, ForceMode.Force);
    }

    public void Jump(float force)
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    public bool CheckGrounded()
    {
        return Physics.CheckSphere(
            transform.position - new Vector3(0, 0.5f, 0),
            groundCheckRadius,
            groundLayer
        );
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    // ボールの回転を制御
    public void SetRotation(float rotationSpeed)
    {
        rb.angularVelocity = new Vector3(
            rb.velocity.z,
            0,
            -rb.velocity.x
        ) * rotationSpeed;
    }
} 