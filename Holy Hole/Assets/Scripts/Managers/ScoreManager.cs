using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{

    public int score = 0;
    public int objectsEaten = 0;

    public void AddScore(int scoreToAdd)
    {
        objectsEaten++;
        score += scoreToAdd;
        UIManager.Instance.UpdateScoreText(score);
    }

    public void RemoveScore(int scoreToRemove)
    {
        score -= scoreToRemove;
    }


}
