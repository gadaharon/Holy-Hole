using UnityEngine;

public class BuildingStats : MonoBehaviour
{
    public float eatSizeThreshold;
    public int pointOnEat;
    public new string name;

    // Fall parameters
    float fallSpeed = 5f;
    float rotationSpeed = 70f;

    bool isFalling = false;

    public void GivePlayerScore()
    {
        ScoreManager.Instance.AddScore(pointOnEat);
    }

    void Update()
    {
        if (isFalling)
        {
            HandleFall();
        }
    }

    public void Fall()
    {
        isFalling = true;
    }

    void HandleFall()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.transform.position, fallSpeed * Time.deltaTime);

        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, fallSpeed * Time.deltaTime);

        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        if (transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
