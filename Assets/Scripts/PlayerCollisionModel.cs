using UnityEngine;
using R3;

public class PlayerCollisionModel
{
    // 衝突したオブジェクトの名前を監視するReactiveProperty
    public ReactiveProperty<string> CollidedObjectName { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="objectName"></param>
    public PlayerCollisionModel(string objectName)
    {
        CollidedObjectName = new ReactiveProperty<string>(objectName);
    }

    // 衝突時にデータ更新
    public void SetCollisionObject(string objectName)
    {
        CollidedObjectName.Value = objectName;
    }
}
