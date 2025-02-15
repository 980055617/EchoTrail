using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class PutSystem : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList; // ボタンリスト
    [SerializeField] private Transform spawnPoint; // インスタンシエイトの基準点
    [SerializeField] private SoundManager soundManager; // サウンドマネージャー

    private void Start()
    {
        foreach (var button in buttonList)
        {
            string buttonName = button.name; // キャプチャしてクロージャ問題を回避

            // マウスオーバー時の処理を登録
            button.OnPointerEnterAsObservable()
                .Subscribe(_ => SoundManager.Instance.PlaySE((SoundManager.SEData.SETYPE)Enum.Parse(typeof(SoundManager.SEData.SETYPE), buttonName)))
                .AddTo(this);

            // クリック時の処理を登録
            button.OnClickAsObservable()
                .Subscribe(_ => InstantiateObject(buttonName))
                .AddTo(this);
        }
    }

    private void InstantiateObject(string objectName)
    {
        GameObject prefab = Resources.Load<GameObject>(objectName);
        if (prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"Prefab {objectName} が Resources に見つかりません。");
        }
    }
}
