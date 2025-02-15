using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class PlayerCollisionPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerCollisionModel _playerCollisionModel;
    [SerializeField]
    private PlayerCollisionView _playerCollisionView;


    void Start()
    {
        _playerCollisionModel = new PlayerCollisionModel("");

        // Bind();
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
    //         .AddTo(_playerCollisionView);
    // }

    public void OnPlayerCollision(string objectName)
    {
        _playerCollisionModel.SetCollisionObject(objectName);
    }
}
