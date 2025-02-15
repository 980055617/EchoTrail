using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultPresenter
{
    private readonly GameResultModel model;
    private readonly GameResultView view;

    public GameResultPresenter(GameResultModel model, GameResultView view)
    {
        this.model = model;
        this.view = view;

        // ボタンのリスナーを設定
        view.AddRetryListener(OnRetryClicked);
        view.AddTitleListener(OnTitleClicked);
    }

    public void ShowResults()
    {
        view.Show();
        view.SetScore(model.Score);
        view.SetPlayTime(model.PlayTime);
        view.SetCollectedItems(model.CollectedItems);
    }

    private void OnRetryClicked()
    {
        view.Hide();
        SceneManager.LoadScene("GameScene");
    }

    private void OnTitleClicked()
    {
        view.Hide();
        SceneManager.LoadScene("TitleScene");
    }
} 