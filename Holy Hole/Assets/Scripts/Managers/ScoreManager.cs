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

    public void SaveTopScore()
    {
        int topScore = LoadTopScore();
        if (score > topScore)
        {
            Debug.Log("SAVED TOP SCORE");
            PlayerPrefs.SetInt("topScore", score);
            PlayerPrefs.Save();
        }
    }

    public int LoadTopScore()
    {
        int topScore = PlayerPrefs.GetInt("topScore", 0);
        return topScore;
    }


}
