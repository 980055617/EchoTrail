using UnityEngine;

public class MainBallView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float groundCheckRadius = 0.5f;
    [SerializeField] private LayerMask groundLayer = -1;

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
        // デバッグ用の視覚化（開発時のみ）
        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
        
        // 球体の接地判定を行う
        return Physics.CheckSphere(
            transform.position - new Vector3(0, 0.5f, 0),  // ボールの下部で判定
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

    public void SetBounceVelocity(float bounceForce)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var bounceSettings = collision.gameObject.GetComponent<BounceSettings>();
        if (bounceSettings != null)
        {
            // BounceSettingsコンポーネントから直接跳ね返り力を取得
            SetBounceVelocity(bounceSettings.BounceForce);
        }
    }

    // Presenterに通知するためのイベント
    public event System.Action<string> OnBallCollision;
} 