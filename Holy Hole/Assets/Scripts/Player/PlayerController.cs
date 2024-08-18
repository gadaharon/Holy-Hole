using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] int holeSize = 1;
    [SerializeField] float speed = 8f;

    int score = 0;
    int growTarget = 5;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }


    void OnEatObject(int points)
    {
        score += points;
        if (score >= growTarget)
        {
            growTarget *= 4;
            holeSize += 5;
            transform.localScale = transform.localScale * 2f;
            Camera.main.orthographicSize += 5;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EatableObject eatableObject = other.gameObject.GetComponent<EatableObject>();
        if (eatableObject != null)
        {
            if (eatableObject.Size <= holeSize)
            {
                OnEatObject(eatableObject.Points);
                Destroy(other.gameObject);
            }
        }
    }
}
