using UnityEngine;

public class ScoreManager : MonoBehaviour {

    #region Singleton
    public static ScoreManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    public float score;
    public int objectsEaten;

    public void AddScore(float scoreToAdd) {
        objectsEaten++;
        score += scoreToAdd;
    }

    public void RemoveScore(float scoreToRemove) {
        score -= scoreToRemove;
    }


}
