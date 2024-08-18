using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{

    public float score = 0;
    public int objectsEaten = 0;

    public void AddScore(float scoreToAdd)
    {
        objectsEaten++;
        score += scoreToAdd;
    }

    public void RemoveScore(float scoreToRemove)
    {
        score -= scoreToRemove;
    }


}
