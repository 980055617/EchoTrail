using UnityEngine;

public class MainBallPresenter : MonoBehaviour
{
    private MainBallModel model;
    private MainBallView view;

    private void Start()
    {
        model = new MainBallModel();
        view = GetComponent<MainBallView>();
        
        // 初期パラメータの設定
        model.SetMovementParameters(
            speed: 5f,
            jump: 5f
        );
        
        // 衝突イベントの購読
        view.OnBallCollision += HandleCollision;
    }

    private void Update()
    {
        // 接地判定の更新
        model.IsGrounded = view.CheckGrounded();
        Debug.Log(view.CheckGrounded());
        // 接地している間、毎フレームログを表示
        if (model.IsGrounded)
        {
            Debug.Log("ボールは地面に接地しています");
        }

        // 入力処理
        HandleInput();
    }

    private void FixedUpdate()
    {
        // 移動処理
        HandleMovement();
        
        // ボールの回転
        view.SetRotation(2f);
        
        // 現在の速度を保存
        model.Velocity = view.GetVelocity();
    }

    private void HandleInput()
    {
        // ジャンプ入力
        if (Input.GetButtonDown("Jump") && model.IsGrounded)
        {
            view.Jump(model.JumpForce);
        }
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * model.MoveSpeed;
        view.Move(movement);
    }

    // 追加の機能例：
    public void BoostSpeed(float multiplier, float duration)
    {
        StartCoroutine(BoostSpeedCoroutine(multiplier, duration));
    }

    private System.Collections.IEnumerator BoostSpeedCoroutine(float multiplier, float duration)
    {
        float originalSpeed = model.MoveSpeed;
        model.SetMovementParameters(originalSpeed * multiplier, model.JumpForce);
        
        yield return new WaitForSeconds(duration);
        
        model.SetMovementParameters(originalSpeed, model.JumpForce);
    }

    private void HandleCollision(string objectTag)
    {
        float bounceForce = model.GetBounceForce(objectTag);
        Debug.Log($"衝突したオブジェクトのタグ: {objectTag}, 跳ね返りの強さ: {bounceForce}");
        view.SetBounceVelocity(bounceForce);
    }

    private void OnDestroy()
    {
        // イベントの購読解除
        view.OnBallCollision -= HandleCollision;
    }
} 