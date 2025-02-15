using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameResultView : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI playTimeText;
    [SerializeField] private TextMeshProUGUI itemsText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button titleButton;

    public void Show()
    {
        resultPanel.SetActive(true);
    }

    public void Hide()
    {
        resultPanel.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = $"スコア: {score}";
    }

    public void SetPlayTime(int seconds)
    {
        playTimeText.text = $"プレイ時間: {seconds}秒";
    }

    public void SetCollectedItems(int items)
    {
        itemsText.text = $"収集アイテム: {items}個";
    }

    public void AddRetryListener(UnityEngine.Events.UnityAction action)
    {
        retryButton.onClick.AddListener(action);
    }

    public void AddTitleListener(UnityEngine.Events.UnityAction action)
    {
        titleButton.onClick.AddListener(action);
    }
} 