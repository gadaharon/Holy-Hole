using UnityEngine;

public class BuildingStats : MonoBehaviour
{
    public bool HasFallen => hasFallen;

    public float eatSizeThreshold;
    public int pointOnEat;
    public new string name;

    // Fall parameters
    float fallSpeed = 5f;
    float rotationSpeed = 70f;

    bool hasFallen = false;

    public void GivePlayerScore()
    {
        if (!hasFallen)
        {
            ScoreManager.Instance.AddScore(pointOnEat);
            hasFallen = true;
        }
    }

    void Update()
    {
        if (hasFallen)
        {
            HandleFall();
        }
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
