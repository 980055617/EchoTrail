using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class PlayerCollisionPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerCollisionView _playerCollisionView;


    void Start()
    {
        //Bind();
    }

    /// <summary>
    /// データのバインド
    /// </summary>
    // void Bind()
    // {
    //     // Modelのデータが変更されたらViewに通知
    //     _playerCollisionModel.CollidedObjectName
    //         .Skip(1) // 初期値の通知をスキップ
    //         .Subscribe(objectName =>
    //         {
    //             _playerCollisionView.PlaySE(objectName);
    //         })
    //         .AddTo(gameObject);
    // }

    public void CalledPlayerCollision(string objectName)
    {
        SoundManager.Instance.PlaySE(SoundManager.SEData.SETYPE.EnemyDash);
    }
}
