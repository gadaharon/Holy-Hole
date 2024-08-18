using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    #region Singleton
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

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
