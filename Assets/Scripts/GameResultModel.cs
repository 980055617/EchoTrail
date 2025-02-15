public class GameResultModel
{
    private int score;
    private int playTime;
    private int collectedItems;

    public int Score => score;
    public int PlayTime => playTime;
    public int CollectedItems => collectedItems;

    public void SetGameResults(int score, int playTime, int collectedItems)
    {
        this.score = score;
        this.playTime = playTime;
        this.collectedItems = collectedItems;
    }
} 