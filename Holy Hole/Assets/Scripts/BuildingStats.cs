using UnityEngine;

public class BuildingStats : MonoBehaviour {
    public float eatSizeThreshold;
    public int pointOnEat;
    public new string name;

    public void GivePlayerScore() {
        ScoreManager.instance.AddScore(pointOnEat);
    }
}
